using System;

namespace Catharsium.Util.Enums
{
    public static class CodeHelper
    {
        public static T GetByCode<T>(this T enumeration, string code) where T : struct, IConvertible
        {
            throw new NotImplementedException();
        }
    }
}