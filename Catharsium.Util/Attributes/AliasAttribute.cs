using System;

namespace Catharsium.Util.Attributes
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