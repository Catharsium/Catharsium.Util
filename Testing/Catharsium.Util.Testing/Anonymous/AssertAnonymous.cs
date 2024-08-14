using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Catharsium.Util.Testing.Anonymous;

public static class AssertAnonymous
{
    public static void AreEqual<TExpected, TActual>(TExpected expected, TActual actual) {
        var expectedType = expected.GetType();
        var actualType = actual.GetType();
        var result = (TExpected)ConvertToType(actual, expectedType, actualType);
        Assert.AreEqual(expected, result);
    }


    private static object ConvertToType(object instance, Type fromType, Type toType) {
        var constructor = fromType.GetConstructors().Single();
        var parameters = constructor.GetParameters()
            .Select(parameter => GetValue(instance, toType, parameter))
            .ToArray();
        return constructor.Invoke(parameters);
    }


    private static object GetValue(object instance, Type instanceType, ParameterInfo parameterInfo) {
        var property = instanceType.GetProperty(parameterInfo.Name);
        var propertyValue = property.GetValue(instance);
        return !parameterInfo.ParameterType.IsAnonymousType()
            ? propertyValue
            : ConvertToType(propertyValue, parameterInfo.ParameterType, property.PropertyType);
    }


    public static bool IsAnonymousType(this object instance) {
        return instance != null
            && instance.GetType().Namespace == null;
    }
}