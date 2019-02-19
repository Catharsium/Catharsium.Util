using Catharsium.Util.Validation;

namespace Catharsium.Util.Tests._Mocks
{
    internal class MockObjectWithRequiredWithValidation
    {
        [RequiredWith(nameof(Property2))]
        public string Property1 { get; set; }

        [RequiredWith(nameof(Property1))]
        public string Property2 { get; set; }
    }
}