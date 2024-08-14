namespace Catharsium.Util.IO.Files.Interfaces;

public interface IFile
{
    #region FileInfo Properties

    FileAttributes Attributes { get; set; }

    DateTime CreationTime { get; }

    DateTime CreationTimeUtc { get; }

    IDirectory Directory { get; }

    string DirectoryName { get; }

    bool Exists { get; }

    string Extension { get; }

    string FullName { get; }

    bool IsReadOnly { get; set; }

    DateTime LastAccessTime { get; }

    DateTime LastAccessTimeUtc { get; }

    DateTime LastWriteTime { get; }

    DateTime LastWriteTimeUtc { get; }

    string Name { get; }

    string ExtensionlessName { get; }

    long Length { get; }

    #endregion

    #region FileInfo Methods

    StreamWriter AppendText();

    IFile CopyTo(string destFileName);

    FileStream Create();

    StreamWriter CreateText();

    void Decrypt();

    void Delete();

    void Encrypt();

    void MoveTo(string destFileName);

    FileStream Open(FileMode mode);

    FileStream Open(FileMode mode, FileAccess access);

    FileStream Open(FileMode mode, FileAccess access, FileShare share);

    FileStream OpenRead();

    StreamReader OpenText();

    FileStream OpenWrite();

    void Refresh();

    void Replace(string destinationFileName, string destinationBackupFileName);

    void Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors);

    #endregion
}