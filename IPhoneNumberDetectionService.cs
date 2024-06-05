namespace PhoneNumberDetection.Interfaces
{
    public interface IPhoneNumberDetectionService
    {
        List<string> DetectPhoneNumbers(string input);
    }
}
