using Catharsium.Util.IO.Files.Interfaces;

namespace Catharsium.Util.IO.Files.Services;

public class FileNameService : IFileNameService
{
    public string SuggestValidFileName(string fileName, string replacement = "_") {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        return string.Join(replacement, fileName.Split(invalidCharacters, StringSplitOptions.RemoveEmptyEntries));
    }
}