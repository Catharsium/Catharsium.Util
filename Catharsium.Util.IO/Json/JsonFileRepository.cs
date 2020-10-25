using Catharsium.Util.IO.Interfaces;
using System.Collections.Generic;
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


        public async Task<IEnumerable<T>> LoadAll()
        {
            return await Task.Run<IEnumerable<T>>(() =>
            {
                var directory = this.fileFactory.CreateDirectory($@"{this.storagePath}");
                var result = new List<T>();
                foreach (var file in directory.GetFiles())
                {
                    result.AddRange(this.Load(file));
                }

                return result;
            });
        }


        public async Task<IEnumerable<T>> Load(string fileName)
        {
            return await Task.Run(() =>
            {
                var file = this.fileFactory.CreateFile($@"{this.storagePath}\{fileName}.json");
                return this.Load(file);
            });
        }


        private IEnumerable<T> Load(IFile file)
        {
            return this.jsonFileReader.ReadFrom<IEnumerable<T>>(file);
        }


        public async Task Store(IEnumerable<T> data, string fileName)
        {
            await Task.Run(() => this.jsonFileWriter.Write(data, $@"{this.storagePath}\{fileName}.json"));
        }
    }
}