using System;

namespace Catharsium.Util.Testing.Models;

public class Dependency
{
    public Type Type { get; set; }
    public string Name { get; set; }
    public object Value { get; set; }


    public Dependency(Type type, string name, object value = null)
    {
        this.Type = type;
        this.Name = name;
        this.Value = value;
    }
}