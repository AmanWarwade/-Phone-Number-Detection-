using PhoneNumberDetection.Interfaces;
using System.Text.RegularExpressions;

namespace PhoneNumberDetection.Services
{
    public class PhoneNumberDetectionService : IPhoneNumberDetectionService
    {
        public List<string> DetectPhoneNumbers(string input)
        {
            var phoneNumbers = new List<string>();
            var phonePattern = @"(\+?\d{1,3}[-.\s]?(\(?\d{1,4}\)?[-.\s]?)?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9})|(\b(([\u0900-\u097F]+)|0|1|2|3|4|5|6|7|8|9|ONE|TWO|THREE|FOUR|FIVE|SIX|SEVEN|EIGHT|NINE|ZERO|एक|दो|तीन|चार|पांच|छह|सात|आठ|नौ|शून्य)\b[\s]*){10,}";

            Regex regex = new Regex(phonePattern, RegexOptions.IgnoreCase);

            MatchCollection matches = regex.Matches(input.ToUpper());
            foreach (Match match in matches)
            {
                phoneNumbers.Add(match.Value);
            }

            return phoneNumbers;
        }
    }
}
