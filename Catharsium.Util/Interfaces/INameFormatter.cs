namespace Catharsium.Util.Interfaces;

public interface INameFormatter
{
    string Format(string format, string firstName, string lastName);
    string Format(string format, string firstName, string infix, string lastName);
    string Format(string format, string prefix, string firstName, string infix, string lastName);
}