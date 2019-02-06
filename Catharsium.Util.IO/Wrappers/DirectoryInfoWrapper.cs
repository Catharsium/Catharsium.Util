using System;
using System.IO;

namespace Catharsium.Util.IO.Wrappers
{
    public class DirectoryInfoWrapper : IDirectory
    {
        private readonly IFileFactory fileFactory;
        private readonly DirectoryInfo directory;


        public DirectoryInfoWrapper(IFileFactory fileFactory, string path)
        : this(fileFactory, new DirectoryInfo(path))
        {
        }


        public DirectoryInfoWrapper(IFileFactory fileFactory, DirectoryInfo directoryInfo)
        {
            this.fileFactory = fileFactory;
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

        public IDirectory Parent => this.fileFactory.CreateDirectory(this.directory.Parent.FullName);

        public IDirectory Root => this.fileFactory.CreateDirectory(this.directory.Root.FullName);

        #endregion
    }
}