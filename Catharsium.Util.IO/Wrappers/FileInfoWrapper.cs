using System;
using System.IO;

namespace Catharsium.Util.IO.Wrappers
{
    public class FileInfoWrapper : IFile
    {
        private readonly IFileFactory fileFactory;
        private readonly FileInfo file;


        public FileInfoWrapper(IFileFactory fileFactory, string path)
        : this(fileFactory, new FileInfo(path))
        {
        }

        public FileInfoWrapper(IFileFactory fileFactory, FileInfo fileInfo)
        {
            this.fileFactory = fileFactory;
            this.file = fileInfo;
        }


        #region FileInfo Properties

        public FileAttributes Attributes {
            get => this.file.Attributes;
            set => this.file.Attributes = value;
        }

        public DateTime CreationTime => this.file.CreationTime;

        public DateTime CreationTimeUtc => this.file.CreationTimeUtc;

        public IDirectory Directory => this.fileFactory.CreateDirectory(this.file.DirectoryName);

        public string DirectoryName => this.file.DirectoryName;

        public bool Exists => this.file.Exists;

        public string Extension => this.file.Extension;

        public string FullName => this.file.FullName;

        public bool IsReadOnly
        {
            get => this.file.IsReadOnly;
            set => this.file.IsReadOnly = value;
        }

        public DateTime LastAccessTime => this.file.LastAccessTime;

        public DateTime LastAccessTimeUtc => this.file.LastAccessTimeUtc;

        public DateTime LastWriteTime => this.file.LastWriteTime;

        public DateTime LastWriteTimeUtc => this.file.LastWriteTimeUtc;

        public string Name => this.file.Name;

        public long Length => this.file.Length;

        #endregion
    }
}