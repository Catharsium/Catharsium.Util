using Catharsium.Util.IO.Wrappers;

namespace Catharsium.Util.IO
{
    public interface IFileFactory
    {
        IDirectory CreateDirectory(string path);
        IFile CreateFile(string path);
    }
}