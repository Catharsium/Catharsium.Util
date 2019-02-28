using System.ComponentModel.DataAnnotations;

namespace Catharsium.Util.Tests._Mocks
{
    public class MockObjectWithDisplayAttribute
    {
        [Display(Name = "My name")]
        public string PropertyWithDisplayAttribute { get; set; }

        public string PropertyWithoutAttributes { get; set; }
    }
}