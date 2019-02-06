using System;
using System.IO;

namespace Catharsium.Util.IO.Wrappers
{
    public interface IFile
    {
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

        long Length { get; }
    }
}