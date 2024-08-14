using Catharsium.Util.IO.Files.Interfaces;

namespace Catharsium.Util.IO.Files.Json;

public class JsonFileRepository<T>(
    IFileFactory fileFactory,
    IJsonFileReader jsonFileReader,
    IJsonFileWriter jsonFileWriter,
    string storagePath) : IDataRepository<T>
{
    private readonly IFileFactory fileFactory = fileFactory;
    private readonly IJsonFileReader jsonFileReader = jsonFileReader;
    private readonly IJsonFileWriter jsonFileWriter = jsonFileWriter;
    private readonly string storagePath = storagePath;


    public virtual async Task<List<T>> Get() {
        return await Task.Run(() => {
            var directory = this.fileFactory.CreateDirectory($@"{this.storagePath}");
            if(!directory.Exists) {
                directory.Create();
            }

            var result = new List<T>();
            foreach(var file in directory.GetFiles("*.json")) {
                result.Add(this.Get(file));
            }

            return result;
        });
    }


    public virtual async Task<T> Get(string key) {
        var file = this.GetFile(key);
        return await Task.Run(() => this.Get(file));
    }


    private T Get(IFile file) {
        return !file.Exists
            ? throw new IOException($"File '{file.FullName}' does not exist")
            : this.jsonFileReader.ReadFrom<T>(file);
    }


    public virtual async Task Add(T data, string key) {
        var file = this.GetFile(key);
        if(file.Exists) {
            file.Delete();
        }

        await Task.Run(() => this.jsonFileWriter.Write(data, file));
    }


    public virtual async Task Remove(string key) {
        var file = this.GetFile(key);
        if(!file.Exists) {
            throw new IOException($"File '{file.FullName}' does not exist");
        }

        await Task.Run(file.Delete);
    }


    private IFile GetFile(string key) {
        return this.fileFactory.CreateFile($@"{this.storagePath}\{key}.json");
    }
}