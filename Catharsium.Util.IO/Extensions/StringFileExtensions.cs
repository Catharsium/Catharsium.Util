using System;
using System.IO;

namespace Catharsium.Util.IO.Extensions
{
    public static class StringFileExtensions
    {
        public static bool IsFile(this string path)
        {
            try
            {
                var attributes = File.GetAttributes(path);
                return (attributes & FileAttributes.Directory) != FileAttributes.Directory;
            }
            catch (Exception) { }
            return false;
        }


        public static bool IsDirectory(this string path)
        {
            try
            {
                var attributes = File.GetAttributes(path);
                return (attributes & FileAttributes.Directory) == FileAttributes.Directory;
            }
            catch (Exception) { }
            return false;
        }
    }
}