using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Web.Areas.RoomManagement.Controllers
{
  [Area("RoomManagement")]
  [Authorize]
  public class AppointmentsController : Controller
  {
    private readonly IAppointmentService appointmentService;
    private readonly IDoctorService doctorService;
    private readonly IRoomService roomService;
    private readonly IPatientService patientService;

    public AppointmentsController(IAppointmentService appointmentService, IDoctorService doctorService, IRoomService roomService, IPatientService patientService)
    {
      this.appointmentService = appointmentService;
      this.doctorService = doctorService;
      this.roomService = roomService;
      this.patientService = patientService;
    }

    public IActionResult Index()
    {
      return View(appointmentService.GetAll(1, 10));
    }

    [HttpGet]
    public IActionResult Create()
    {
      ViewBag.doctors = new SelectList(doctorService.GetAllDoctors(), "Id", "Name");
      ViewBag.rooms = new SelectList(roomService.GetAll(), "Id", "RoomNumber");
      ViewBag.patients = new SelectList(patientService.GetAll(), "Id", "Name");
      return View();
    }

    [HttpPost]
    public IActionResult Create(AppointmentViewModel vm)
    {
      appointmentService.CreateAppointment(vm);
      return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
      ViewBag.doctors = new SelectList(doctorService.GetAllDoctors(), "Id", "Name");
      ViewBag.rooms = new SelectList(roomService.GetAll(), "Id", "RoomNumber");
      ViewBag.patients = new SelectList(patientService.GetAll(), "Id", "Name");
      return View(appointmentService.GetAppointmentById(id));
    }

    [HttpPost]
    public IActionResult Edit(AppointmentViewModel vm)
    {
      appointmentService.UpdateAppointment(vm);
      return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
      appointmentService.DeleteAppointment(id);
      return RedirectToAction("Index");
    }
  }
}
