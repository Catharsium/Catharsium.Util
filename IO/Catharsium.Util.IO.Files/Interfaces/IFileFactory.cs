namespace Catharsium.Util.IO.Files.Interfaces;

public interface IFileFactory
{
    IDirectory CreateDirectory(string path);
    IDirectory CreateDirectory(DirectoryInfo directoryInfo);

    IFile CreateFile(string path);
    IFile CreateFile(FileInfo fileInfo);
}