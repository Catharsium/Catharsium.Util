namespace Catharsium.Util.Reflection.Attributes.Extensions;

public static class GetAttributeExtensions
{
    public static T GetAttribute<T>(this object subject) where T : Attribute
    {
        var type = subject.GetType();
        var attributes = type.GetCustomAttributes(typeof(T), false);
        return attributes.Any()
            ? (T)attributes.FirstOrDefault()
            : default;
    }


    public static T GetAttribute<T>(this object subject, string memberName) where T : Attribute
    {
        var type = subject.GetType();
        var memberInfo = type.GetMember(memberName);
        if (memberInfo.Length <= 0) {
            return default;
        }

        var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
        return attributes.Any()
            ? (T)attributes.FirstOrDefault()
            : default;
    }


    public static T GetMemberAttribute<T>(this object subject) where T : Attribute
    {
        return subject.GetAttribute<T>(subject.ToString());
    }
}