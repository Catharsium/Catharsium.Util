namespace Catharsium.Util.Reflection.Attributes.Extensions;

public static class HasAttributeExtensions
{
    public static bool HasAttribute<T>(this object subject) where T : Attribute
    {
        return subject.GetAttribute<T>() != null;
    }


    public static bool HasAttribute<T>(this object subject, string memberName) where T : Attribute
    {
        return subject.GetAttribute<T>(memberName) != null;
    }
}