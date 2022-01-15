namespace Catharsium.Util.Configuration.Interfaces;

public interface IRegisteredTypeRetriever<Tbase>
{
    Tchild Get<Tchild>() where Tchild : Tbase;
}