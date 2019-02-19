using Catharsium.Util.Validation;

namespace Catharsium.Util.Tests._Mocks
{
    internal class MockObject
    {
        [GroupRequired("Group 1")]
        public string Property1 { get; set; }

        [GroupRequired("Group 1")]
        public string Property2 { get; set; }

        [GroupRequired("Group 2")]
        public string Property3 { get; set; }

        [GroupRequired("Group 2")]
        public string Property4 { get; set; }
    }
}