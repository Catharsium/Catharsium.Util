using System;

namespace Catharsium.Util.Attributes
{
    public class ReplacedWithAttribute : Attribute
    {
        private readonly Type replacementType;


        public ReplacedWithAttribute(Type replacementType)
        {
            this.replacementType = replacementType;
        }


        public override string ToString()
        {
            return " " + this.replacementType.FullName;
        }
    }
}