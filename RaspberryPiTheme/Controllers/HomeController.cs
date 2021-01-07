using Microsoft.AspNetCore.Mvc;
using OrchardCore.Themes.RaspberryPiTheme.Devices;

namespace OrchardCore.Themes.RaspberryPiTheme.Controllers
{
    public class HomeController : Controller
    {
        private readonly LedDevice _ledDevice;

        public HomeController(LedDevice ledDevice)
        {
            _ledDevice = ledDevice;
        }

        public IActionResult Index()
        {
            ViewBag.LedSupported = _ledDevice.IsLedSupported ? "Yes" : "No";
            ViewBag.LedState = _ledDevice.IsLedOn ? "On" : "Off";
            return View();
        }

        public IActionResult LedOn()
        {
            _ledDevice.LedOn();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult LedOff()
        {
            _ledDevice.LedOff();

            return RedirectToAction(nameof(Index));
        }
    }
}
