namespace Catharsium.Util.Reflection.Attributes;

public class ReplacedWithAttribute(Type replacementType) : Attribute
{
    private readonly Type replacementType = replacementType;


    public override string ToString() {
        return " " + this.replacementType.FullName;
    }
}