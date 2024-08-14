namespace Catharsium.Util.IO.Files.Interfaces;

public interface IFileNameService
{
    string SuggestValidFileName(string fileName, string replacement = "_");
}