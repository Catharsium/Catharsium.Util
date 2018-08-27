using System;

namespace Catharsium.Util.Enums
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