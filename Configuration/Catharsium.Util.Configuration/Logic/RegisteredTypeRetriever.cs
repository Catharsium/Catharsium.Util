using Catharsium.Util.Configuration.Interfaces;
namespace Catharsium.Util.Configuration.Logic;

public class RegisteredTypeRetriever<Tbase> : IRegisteredTypeRetriever<Tbase>
{
    private readonly IEnumerable<Tbase> objects;


    public RegisteredTypeRetriever(IEnumerable<Tbase> objects)
    {
        this.objects = objects;
    }


    public Tchild Get<Tchild>() where Tchild : Tbase
    {
        var result = (Tchild)this.objects.FirstOrDefault(a => a.GetType() == typeof(Tchild));
        return result == null
            ? throw new ArgumentException($"No registeren object of type {typeof(Tchild)} registered as {typeof(Tbase)} was found")
            : result;
    }
}