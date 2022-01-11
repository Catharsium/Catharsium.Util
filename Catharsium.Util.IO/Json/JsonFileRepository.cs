using Catharsium.Util.IO.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Catharsium.Util.IO.Json
{
    public class JsonFileRepository<T> : IJsonFileRepository<T>
    {
        private readonly IFileFactory fileFactory;
        private readonly IJsonFileReader jsonFileReader;
        private readonly IJsonFileWriter jsonFileWriter;
        private readonly string storagePath;


        public JsonFileRepository(
            IFileFactory fileFactory,
            IJsonFileReader jsonFileReader,
            IJsonFileWriter jsonFileWriter,
            string storagePath)
        {
            this.fileFactory = fileFactory;
            this.jsonFileReader = jsonFileReader;
            this.jsonFileWriter = jsonFileWriter;
            this.storagePath = storagePath;
        }


        public async Task<List<T>> Get()
        {
            return await Task.Run(() => {
                var directory = this.fileFactory.CreateDirectory($@"{this.storagePath}");
                var result = new List<T>();
                foreach (var file in directory.GetFiles("*.json")) {
                    result.Add(this.Get(file));
                }

                return result;
            });
        }


        public async Task<T> Get(string key)
        {
            var file = this.GetFile(key);
            return await Task.Run(() => {
                return this.Get(file);
            });
        }


        private T Get(IFile file)
        {
            return !file.Exists
                ? throw new IOException($"File '{file.FullName}' does not exist")
                : this.jsonFileReader.ReadFrom<T>(file);
        }


        public async Task Add(T data, string key)
        {
            var file = this.GetFile(key);
            if (file.Exists) {
                file.Delete();
            }

            await Task.Run(() => this.jsonFileWriter.Write(data, file));
        }


        public async Task Remove(string key)
        {
            var file = this.GetFile(key);
            if (!file.Exists) {
                throw new IOException($"File '{file.FullName}' does not exist");
            }

            await Task.Run(() => file.Delete());
        }


        private IFile GetFile(string key)
        {
            return this.fileFactory.CreateFile($@"{this.storagePath}\{key}.json");
        }
    }
}