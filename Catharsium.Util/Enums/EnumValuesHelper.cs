﻿namespace Catharsium.Util.Enums;

public static class EnumValuesHelper
{
    public static IEnumerable<T> GetValues<T>() where T : struct, IConvertible {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }
}