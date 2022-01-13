using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Threading.Tasks;

namespace Catharsium.Util.IO.Console.Tests._Mocks
{
    public class MyActionHandler : IActionHandler
    {
        public string DisplayName { get; }


        public Task<T> Run<T>()
        {
            throw new NotImplementedException();
        }
    }
}