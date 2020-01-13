namespace Catharsium.Util.IO.Interfaces
{
    public interface IJsonFileWriter
    {
        void Write(object data, string file);
        void Write(object data, IFile file);
    }
}