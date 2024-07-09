using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Patient.Controllers
{
  [Area("Patient")]
  [Authorize]
  public class PatientController : Controller
  {
    private readonly IPatientService patientService;

    public PatientController(IPatientService patientService)
    {
      this.patientService = patientService;
    }

    public IActionResult Index()
    {
      return View(patientService.GetAll(1, 10));
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(PatientViewModel model)
    {
      patientService.Create(model);
      return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
      return View(patientService.GetById(id));
    }

    [HttpPost]
    public IActionResult Edit(PatientViewModel model)
    {
      patientService.Update(model);
      return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
      patientService.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
