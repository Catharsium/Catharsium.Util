using Catharsium.Util.Validation;

namespace Catharsium.Util.Tests._Mocks
{
    internal class MockObjectWithOneInGroupRequiredValidation
    {
        [OneInGroupRequired("Group 1")]
        public string Property1 { get; set; }

        [OneInGroupRequired("Group 1")]
        public string Property2 { get; set; }

        [OneInGroupRequired("Group 2")]
        public string Property3 { get; set; }

        [OneInGroupRequired("Group 2")]
        public string Property4 { get; set; }
    }
}