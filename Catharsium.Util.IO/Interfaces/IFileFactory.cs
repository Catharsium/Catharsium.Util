using System.IO;

namespace Catharsium.Util.IO.Interfaces
{
    public interface IFileFactory
    {
        IDirectory CreateDirectory(string path);
        IDirectory CreateFile(DirectoryInfo directoryInfo);

        IFile CreateFile(string path);
        IFile CreateFile(FileInfo fileInfo);
    }
}