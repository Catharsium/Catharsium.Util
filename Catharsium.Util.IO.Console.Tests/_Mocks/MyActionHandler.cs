using Catharsium.Util.IO.Console.Interfaces;
using System.Threading.Tasks;

namespace Catharsium.Util.IO.Console.Tests._Mocks
{
    public class MyActionHandler : IActionHandler
    {
        public string DisplayName { get; }


        public Task<dynamic> Run()
        {
            return Task.FromResult<dynamic>(nameof(MyActionHandler));
        }
    }
}