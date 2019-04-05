using System;
using System.IO;
using Catharsium.Util.IO.Interfaces;

namespace Catharsium.Util.IO.Wrappers
{
    public class FileInfoWrapper : IFile
    {
        private readonly FileInfo file;

        #region Construction

        public FileInfoWrapper(string path)
            : this(new FileInfo(path)) { }


        public FileInfoWrapper(FileInfo fileInfo)
        {
            this.file = fileInfo;
        }

        #endregion

        #region FileInfo Properties

        public FileAttributes Attributes {
            get => this.file.Attributes;
            set => this.file.Attributes = value;
        }

        public DateTime CreationTime => this.file.CreationTime;

        public DateTime CreationTimeUtc => this.file.CreationTimeUtc;

        public IDirectory Directory => new DirectoryInfoWrapper(this.file.Directory);

        public string DirectoryName => this.file.DirectoryName;

        public bool Exists => this.file.Exists;

        public string Extension => this.file.Extension;

        public string FullName => this.file.FullName;

        public bool IsReadOnly {
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

        #region FileInfo Methods

        public StreamWriter AppendText()
        {
            return this.file.AppendText();
        }


        public IFile CopyTo(string destFileName)
        {
            return new FileInfoWrapper(this.file.CopyTo(destFileName));
        }


        public FileStream Create()
        {
            return this.file.Create();
        }


        public StreamWriter CreateText()
        {
            return this.file.CreateText();
        }


        public void Decrypt()
        {
            this.file.Decrypt();
        }


        public void Delete()
        {
            this.file.Delete();
        }


        public void Encrypt()
        {
            this.file.Encrypt();
        }


        public void MoveTo(string destFileName)
        {
            this.file.MoveTo(destFileName);
        }


        public FileStream Open(FileMode mode)
        {
            return this.file.Open(mode);
        }


        public FileStream Open(FileMode mode, FileAccess access)
        {
            return this.file.Open(mode, access);
        }


        public FileStream Open(FileMode mode, FileAccess access, FileShare share)
        {
            return this.file.Open(mode, access, share);
        }


        public FileStream OpenRead()
        {
            return this.file.OpenRead();
        }


        public StreamReader OpenText()
        {
            return this.file.OpenText();
        }


        public FileStream OpenWrite()
        {
            return this.file.OpenWrite();
        }


        public void Refresh()
        {
            this.file.Refresh();
        }


        public void Replace(string destinationFileName, string destinationBackupFileName)
        {
            this.file.Replace(destinationFileName, destinationBackupFileName);
        }


        public void Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors)
        {
            this.file.Replace(destinationFileName, destinationBackupFileName, ignoreMetadataErrors);
        }

        #endregion
    }
}