﻿namespace Catharsium.Util.IO.Interfaces
{
    public interface IJsonFileReader
    {
        T ReadFrom<T>(string file);
    }
}