using System.Reflection;
namespace Catharsium.Util.Reflection.Properties;

public static class PropertyExtensions
{
    public static object SetProperty(this object obj, string name, object value)
    {
        var property = obj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
        if (null != property && property.CanWrite) {
            property.SetValue(obj, value, null);
        }

        return obj;
    }


    public static PropertyInfo[] GetPropertiesWithValue(this object obj)
    {
        return obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .Where(p => p.GetValue(obj) != null)
                            .ToArray();
    }
}