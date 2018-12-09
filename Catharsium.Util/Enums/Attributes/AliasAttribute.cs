using System;

namespace Catharsium.Util.Enums.Attributes
{
    public class AliasAttribute : Attribute
    {
        public string[] Aliases { get; }


        public AliasAttribute(params string[] aliases)
        {
            this.Aliases = aliases;
        }
    }
}