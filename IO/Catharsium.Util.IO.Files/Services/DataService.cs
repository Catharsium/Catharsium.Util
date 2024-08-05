using Catharsium.Util.IO.Files.Interfaces;
using Catharsium.Util.IO.Files.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Util.IO.Files.Services;

public class DataService<T>(IJsonFileRepository<T> fileRepository, IFileNameService fileNameService) : IDataService<T> where T : BaseItem
{
    private readonly IJsonFileRepository<T> gearRepository = fileRepository;
    private readonly IFileNameService fileNameService = fileNameService;


    public async Task<List<T>> Get()
    {
        return await this.gearRepository.Get();
    }


    public async Task<T> Get(Guid itemId)
    {
        return (await this.gearRepository.Get()).FirstOrDefault(b => b.Id == itemId)!;
    }


    public async Task Remove(Guid itemId)
    {
        var list = await this.Get();
        var item = list.Single(g => g.Id == itemId);
        list.Remove(item);
    }


    public async Task Add(T item)
    {
        await this.gearRepository.Add(item, this.GetKey(item));
    }


    public async Task Update(T item)
    {
        await this.Remove(item.Id);
        await this.Add(item);
    }


    private string GetKey(T item)
    {
        var maxLength = 150;
        var itemKey = this.fileNameService.SuggestValidFileName(item.ToString());
        return itemKey.Length > maxLength ? itemKey[..maxLength] : itemKey;
    }


    public virtual async Task<List<T>> Search(string query)
    {
        var items = await this.Get();
        return items.Where(g =>
            g.Id.ToString().Contains(query, StringComparison.CurrentCultureIgnoreCase)
        ).ToList();
    }
}