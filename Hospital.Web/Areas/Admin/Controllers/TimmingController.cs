using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;



public class TimingController : Controller
{
    private readonly IDoctorService _doctorService;

    public TimingController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpPost]
    public IActionResult AddTiming(TimingViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            _doctorService.AddTiming(model);
            return RedirectToAction("SuccessPage"); 
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(model); 
        }
    }
}
