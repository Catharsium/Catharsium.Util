using System;
using System.Linq;

namespace Catharsium.Util.Attributes.Extensions
{
    public static class AttributeHelper
    {
        public static T GetAttribute<T>(this object value) where T : Attribute
        {
            var type = value.GetType();
            var attributes = type.GetCustomAttributes(typeof(T), false);
            if (attributes.Any()) {
                return (T)attributes.FirstOrDefault();
            }

            return default(T);
        }


        public static T GetAttribute<T>(this object value, string propertyName) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(propertyName);
            if (memberInfo.Length > 0) {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
                if (attributes.Any()) {
                    return (T)attributes.FirstOrDefault();
                }
            }

            return default(T);
        }
    }
}