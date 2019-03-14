using System;
using System.Linq;

namespace Catharsium.Util.Attributes.Extensions
{
    public static class AttributeExtensions
    {
        public static T GetAttribute<T>(this object subject) where T : Attribute
        {
            var type = subject.GetType();
            var attributes = type.GetCustomAttributes(typeof(T), false);
            return attributes.Any()
                ? (T)attributes.FirstOrDefault()
                : default(T);
        }


        public static T GetAttribute<T>(this object subject, string propertyName) where T : Attribute
        {
            var type = subject.GetType();
            var memberInfo = type.GetMember(propertyName);
            if (memberInfo.Length > 0) {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
                if (attributes.Any()) {
                    return (T)attributes.FirstOrDefault();
                }
            }

            return default(T);
        }

        
        public static T GetMemberAttribute<T>(this object subject) where T : Attribute
        {
            return subject.GetAttribute<T>(subject.ToString());
        }
    }
}