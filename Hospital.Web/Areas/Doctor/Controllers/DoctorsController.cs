using Hospital.Models;
using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Hospital.Web.Areas.Doctor.Controllers
{
  [Area("Doctor")]
  [Authorize]
  public class DoctorsController : Controller
  {
    private readonly IDoctorService _doctorService;


    public DoctorsController(IDoctorService doctorService)
    {
      _doctorService = doctorService;

    }

    public IActionResult Index(int pageNumber = 1, int pageSize = 10)
    {
      return View(_doctorService.GetAll(pageNumber, pageSize));
    }





    [HttpGet]
    public IActionResult AddTiming()
    {
      Timing timing = new Timing();
      List<SelectListItem> morningShiftStart = new List<SelectListItem>();
      List<SelectListItem> morningShiftEnd = new List<SelectListItem>();
      List<SelectListItem> AfternoonShiftStart = new List<SelectListItem>();
      List<SelectListItem> AfternoonShiftEnd = new List<SelectListItem>();

      for (int i = 1; i <= 11; i++)
      {
        morningShiftStart.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });

      }
      for (int i = 1; i <= 13; i++)
      {
        morningShiftEnd.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });

      }
      for (int i = 13; i <= 16; i++)
      {
        AfternoonShiftStart.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });

      }
      for (int i = 13; i <= 18; i++)
      {
        AfternoonShiftEnd.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });

      }
      ViewBag.doctors = new SelectList(_doctorService.GetAllDoctors(), "Id", "Name");
      ViewBag.morningStart = new SelectList(morningShiftStart, "Value", "Text");
      ViewBag.morningEnd = new SelectList(morningShiftEnd, "Value", "Text");
      ViewBag.evenStart = new SelectList(AfternoonShiftStart, "Value", "Text");
      ViewBag.evenEnd = new SelectList(AfternoonShiftEnd, "Value", "Text");
      TimingViewModel vm = new TimingViewModel();
      vm.ScheduleDate = DateTime.Now.AddDays(1);
      return View(vm);
    }

    [HttpPost]
    public IActionResult AddTiming(TimingViewModel vm)
    {
      _doctorService.AddTiming(vm);


      return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
      ViewBag.doctors = new SelectList(_doctorService.GetAllDoctors(), "Id", "Name");
      var viewModel = _doctorService.GetTimingById(id);
      return View(viewModel);
    }
    [HttpPost]
    public IActionResult Edit(TimingViewModel vm)
    {
      _doctorService.UpdateTiming(vm);
      return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
      var vm = _doctorService.GetTimingById(id);
      return View(vm);
    }

    public IActionResult Delete(int id)
    {
      _doctorService.DeleteTiming(id);
      return RedirectToAction("Index");
    }


  }
}
