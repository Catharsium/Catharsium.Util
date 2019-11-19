namespace Catharsium.Util.IO.Interfaces
{
    public interface IJsonFileSerializer
    {
        T ReadAs<T>(string file);
    }
}