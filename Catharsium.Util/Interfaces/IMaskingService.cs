namespace Catharsium.Util.Interfaces;

public interface IMaskingService
{
    string MaskEmail(string email);
    string MaskPhoneNumber(string phoneNumber);
}