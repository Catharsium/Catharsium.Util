using Catharsium.Util.IO.Files.Interfaces;

namespace Catharsium.Util.IO.Files.Json;

public class CachedJsonFileRepository<T>(IFileFactory fileFactory, IJsonFileReader jsonFileReader, IJsonFileWriter jsonFileWriter, string storagePath) :
    JsonFileRepository<T>(fileFactory, jsonFileReader, jsonFileWriter, storagePath)
{
    private List<T> Items { get; set; }


    public override async Task<List<T>> Get() {
        await this.Reload();
        return this.Items;
    }


    public override async Task<T> Get(string key) {
        await this.Reload();
        return await base.Get(key);
    }


    public override async Task Add(T data, string key) {
        await base.Add(data, key);
        await this.Reload();
    }


    public override async Task Remove(string key) {
        await base.Remove(key);
        await this.Reload();
    }


    private async Task Reload() {
        this.Items ??= await base.Get();
    }
}