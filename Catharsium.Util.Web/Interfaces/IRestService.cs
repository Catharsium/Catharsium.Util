namespace Catharsium.Util.Web.Interfaces
{
    public interface IRestService
    {
        string PostToJsonService(string resource, object data);
        long PostToJsonServiceWithLongResponseType(string resource, object data);
    }
}