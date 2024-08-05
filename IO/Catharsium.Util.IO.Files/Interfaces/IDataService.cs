using Catharsium.Util.IO.Files.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Util.IO.Files.Interfaces;

public interface IDataService<T> where T : BaseItem
{
    Task Add(T item);
    Task<List<T>> Get();
    Task<T> Get(Guid itemId);
    Task Remove(Guid itemId);
    Task<List<T>> Search(string query);
    Task Update(T item);
}