using Microsoft.AspNetCore.Mvc;
using PhoneNumberDetection.Interfaces;
using PhoneNumberDetection.Models;

namespace PhoneNumberDetection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPhoneNumberDetectionService _phoneNumberDetectionService;

        public HomeController(IPhoneNumberDetectionService phoneNumberDetectionService)
        {
            _phoneNumberDetectionService = phoneNumberDetectionService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new InputModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(InputModel model)
        {
            if (model.TextInput!=null)
            {
                model.DetectedPhoneNumbers = _phoneNumberDetectionService.DetectPhoneNumbers(model.TextInput);

                if (model.DetectedPhoneNumbers.Any())
                {
                    model.Message = "Phone number detected.";
                }
                else
                {
                    model.Message = "No phone number detected.";
                }

                return View("Index", model);
            }
            return View();
        }
    }
}
