namespace Catharsium.Util.Interfaces;

public interface IMaskingTool
{
    string MaskEmail(string email);
    string MaskPhoneNumber(string phoneNumber);
}