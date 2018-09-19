using System;

namespace Catharsium.Util.Enums.Attributes
{
    public class CodeAttribute : Attribute
    {
        public string[] Codes { get; }


        public CodeAttribute(params string[] codes)
        {
            Codes = codes;
        }
    }
}