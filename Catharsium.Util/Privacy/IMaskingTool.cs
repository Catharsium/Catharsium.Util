namespace Catharsium.Util.Privacy
{
    public interface IMaskingTool
    {
        string MaskEmail(string email);
        string MaskPhoneNumber(string phoneNumber);
    }
}
