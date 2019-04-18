using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Catharsium.Util.IO.Interfaces;

namespace Catharsium.Util.IO.Wrappers
{
    public class DirectoryInfoWrapper : IDirectory
    {
        private readonly DirectoryInfo directory;


        public DirectoryInfoWrapper(string path)
            : this(new DirectoryInfo(path)) { }


        public DirectoryInfoWrapper(DirectoryInfo directoryInfo)
        {
            this.directory = directoryInfo;
        }


        #region DirectoryInfo Properties

        public FileAttributes Attributes {
            get => this.directory.Attributes;
            set => this.directory.Attributes = value;
        }

        public DateTime CreationTime => this.directory.CreationTime;

        public DateTime CreationTimeUtc => this.directory.CreationTimeUtc;

        public bool Exists => this.directory.Exists;

        public string Extension => this.directory.Extension;

        public string FullName => this.directory.FullName;

        public DateTime LastAccessTime => this.directory.LastAccessTime;

        public DateTime LastAccessTimeUtc => this.directory.LastAccessTimeUtc;

        public DateTime LastWriteTime => this.directory.LastWriteTime;

        public DateTime LastWriteTimeUtc => this.directory.LastWriteTimeUtc;

        public string Name => this.directory.Name;

        public IDirectory Parent => new DirectoryInfoWrapper(this.directory.Parent);

        public IDirectory Root => new DirectoryInfoWrapper(this.directory.Root);

        #endregion

        #region DirectoryInfo Methods

        public void Create()
        {
            this.directory.Create();
        }


        public void CreateSubDirectory(string path)
        {
            this.directory.CreateSubdirectory(path);
        }


        public void Delete()
        {
            this.directory.Delete();
        }


        public IEnumerable<IDirectory> EnumerateDirectories()
        {
            return this.directory.EnumerateDirectories().Select(d => new DirectoryInfoWrapper(d));
        }


        public IEnumerable<IDirectory> EnumerateDirectories(string searchPattern)
        {
            return this.directory.EnumerateDirectories(searchPattern).Select(d => new DirectoryInfoWrapper(d));
        }


        public IEnumerable<IDirectory> EnumerateDirectories(string searchPattern, SearchOption searchOption)
        {
            return this.directory.EnumerateDirectories(searchPattern, searchOption).Select(d => new DirectoryInfoWrapper(d));
        }


        public IEnumerable<IFile> EnumerateFiles()
        {
            return this.directory.EnumerateFiles().Select(f => new FileInfoWrapper(f));
        }


        public IEnumerable<IFile> EnumerateFiles(string searchPattern)
        {
            return this.directory.EnumerateFiles(searchPattern).Select(f => new FileInfoWrapper(f));
        }


        public IEnumerable<IFile> EnumerateFiles(string searchPattern, SearchOption searchOption)
        {
            return this.directory.EnumerateFiles(searchPattern, searchOption).Select(f => new FileInfoWrapper(f));
        }


        public IEnumerable<FileSystemInfo> EnumerateFileSystemInfos()
        {
            return this.directory.EnumerateFileSystemInfos();
        }


        public IDirectory[] GetDirectories()
        {
            return this.directory.GetDirectories()
                .Select(d => new DirectoryInfoWrapper(d))
                .ToArray();
        }


        public IDirectory[] GetDirectories(string searchPattern)
        {
            return this.directory.GetDirectories(searchPattern)
                .Select(d => new DirectoryInfoWrapper(d))
                .ToArray();
        }


        public IDirectory[] GetDirectories(string searchPattern, SearchOption searchOption)
        {
            return this.directory.GetDirectories(searchPattern, searchOption)
                .Select(d => new DirectoryInfoWrapper(d))
                .ToArray();
        }


        public IFile[] GetFiles()
        {
            return this.directory.GetFiles()
                .Select(f => new FileInfoWrapper(f.FullName))
                .ToArray();
        }


        public IFile[] GetFiles(string searchPattern)
        {
            return this.directory.GetFiles(searchPattern)
                .Select(f => new FileInfoWrapper(f.FullName))
                .ToArray();
        }


        public IFile[] GetFiles(string searchPattern, SearchOption searchOption)
        {
            return this.directory.GetFiles(searchPattern, searchOption)
                .Select(f => new FileInfoWrapper(f.FullName))
                .ToArray();
        }


        public void MoveTo(string destDirName)
        {
            this.directory.MoveTo(destDirName);
        }


        public void Refresh()
        {
            this.directory.Refresh();
        }

        #endregion
    }
}