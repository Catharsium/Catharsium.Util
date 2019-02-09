using System;
using System.Collections.Generic;
using System.IO;

namespace Catharsium.Util.IO.Interfaces
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
        
        void Create();

        void CreateSubDirectory(string path);

        void Delete();

        IEnumerable<IDirectory> EnumerateDirectories();
        
        IEnumerable<IDirectory> EnumerateDirectories(string searchPattern);

        IEnumerable<IDirectory> EnumerateDirectories(string searchPattern, SearchOption searchOption);
        
        IEnumerable<IFile> EnumerateFiles();

        IEnumerable<IFile> EnumerateFiles(string searchPattern);

        IEnumerable<IFile> EnumerateFiles(string searchPattern, SearchOption searchOption);

        IEnumerable<FileSystemInfo> EnumerateFileSystemInfos();

        IDirectory[] GetDirectories();

        IDirectory[] GetDirectories(string searchPattern);

        IDirectory[] GetDirectories(string searchPattern, SearchOption searchOption);

        IFile[] GetFiles();

        IFile[] GetFiles(string searchPattern);

        IFile[] GetFiles(string searchPattern, SearchOption searchOption);

        void MoveTo(string destDirName);

        void Refresh();

        #endregion
    }
}