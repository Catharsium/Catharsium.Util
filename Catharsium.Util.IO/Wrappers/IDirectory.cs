using System;
using System.IO;

namespace Catharsium.Util.IO.Wrappers
{
    public interface IDirectory
    {
        #region DirectoryInfo Properties

        FileAttributes Attributes { get; set; }

        DateTime CreationTime { get; }

        DateTime CreationTimeUtc { get; }

        bool Exists { get; }

        string Extension { get; }

        string FullName { get; }

        DateTime LastAccessTime { get; }

        DateTime LastAccessTimeUtc { get; }

        DateTime LastWriteTime { get; }

        DateTime LastWriteTimeUtc { get; }

        string Name { get; }

        IDirectory Parent { get; }

        IDirectory Root { get; }

        #endregion

        #region DirectoryInfo Methods

        IFile[] GetFiles();
        
        IFile[] GetFiles(string searchPattern);
        
        IFile[] GetFiles(string searchPattern, SearchOption searchOption);

        #endregion
    }
}