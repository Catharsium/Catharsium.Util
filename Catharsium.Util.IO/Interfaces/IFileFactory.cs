using System.IO;

namespace Catharsium.Util.IO.Interfaces
{
    public interface IFileFactory
    {
        IDirectory CreateDirectory(string path);
        IDirectory CreateDirectory(DirectoryInfo directoryInfo);

        IFile CreateFile(string path);
        IFile CreateFile(FileInfo fileInfo);
    }
}