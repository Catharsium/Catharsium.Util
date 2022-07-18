using Catharsium.Util.IO.Files.Interfaces;
using System;

namespace Catharsium.Util.IO.Files.Services;

public class FileNameService : IFileNameService
{
    public string SuggestValidFileName(string fileName, string replacement = "_")
    {
        var invalidCharacters = System.IO.Path.GetInvalidFileNameChars();
        return string.Join(replacement, fileName.Split(invalidCharacters, StringSplitOptions.RemoveEmptyEntries));
    }
}