using System;

namespace Catharsium.Util.IO.Interfaces
{
    public interface IConsole
    {
        int? ReadInt(string message);
        DateTime? ReadDate(string message);
    }
}