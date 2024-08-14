namespace Catharsium.Util.Testing.Models;

public class Dependency(Type type, string name, object value = null)
{
    public Type Type { get; set; } = type;
    public string Name { get; set; } = name;
    public object Value { get; set; } = value;
}