using System.ComponentModel.DataAnnotations;

namespace PhoneNumberDetection.Models
{
    public class InputModel
    {
        [Required(ErrorMessage = "Requied Field.")]
        public string TextInput { get; set; }

        
        public List<string> DetectedPhoneNumbers { get; set; } = new List<string>();
        public string Message { get; set; }
    }
}
