using System.ComponentModel.DataAnnotations;

namespace Catharsium.Util.Tests._Mocks
{
    [Display(Name = "My class name")]
    public class MockObjectWithDisplayAttribute
    {
        [Display(Name = "My property name")]
        public string PropertyWithDisplayAttribute { get; set; }

        public string PropertyWithoutAttributes { get; set; }
    }
}