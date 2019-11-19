using System.IO;
using Catharsium.Util.IO.Interfaces;

namespace Catharsium.Util.IO.Wrappers
{
    public class FileFactory : IFileFactory
    {
        #region Files

        public IFile CreateFile(string path)
        {
            return new FileInfoWrapper(path);
        }


        public IFile CreateFile(FileInfo fileInfo)
        {
            return new FileInfoWrapper(fileInfo);
        }

        #endregion

        #region Directories

        public IDirectory CreateDirectory(string path)
        {
            return new DirectoryInfoWrapper(path);
        }

        public IDirectory CreateDirectory(DirectoryInfo directoryInfo)
        {
            return new DirectoryInfoWrapper(directoryInfo);
        }

        #endregion
    }
}