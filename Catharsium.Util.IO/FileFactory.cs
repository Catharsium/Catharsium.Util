using Catharsium.Util.IO.Wrappers;

namespace Catharsium.Util.IO
{
    public class FileFactory : IFileFactory
    {
        public IFile CreateFile(string path)
        {
            return new FileInfoWrapper(this, path);
        }


        public IDirectory CreateDirectory(string path)
        {
            return new DirectoryInfoWrapper(this, path);
        }
    }
}