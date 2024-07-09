using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Doctor.Controllers
{
  [Area("Doctor")]
  [Authorize]
  public class AllDoctorsController : Controller
  {
    private readonly IDoctorService doctorService;

    public AllDoctorsController(IDoctorService doctorService)
    {
      this.doctorService = doctorService;
    }



    public IActionResult Index(int pageNumber = 1, int pageSize = 10)
    {
      return View(doctorService.GetAllDoctors(pageNumber, pageSize));
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(DoctorViewModel vm)
    {
      doctorService.CreateDoctor(vm);
      return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
      return View(doctorService.GetDoctorById(id));
    }

    [HttpPost]
    public IActionResult Edit(DoctorViewModel vm)
    {
      doctorService.UpdateDoctor(vm);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var vm = doctorService.GetDoctorById(id);
      return View(vm);
    }

    public IActionResult Delete(int id)
    {
      doctorService.DeleteDoctor(id);
      return RedirectToAction("Index");
    }
  }
}
