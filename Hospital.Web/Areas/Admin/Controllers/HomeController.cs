using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq; 

namespace Hospital.Web.Controllers
{
  [Area("admin")]
  public class HomeController : Controller
  {
    private readonly IDoctorService _doctorService;
    private readonly IAppointmentService _appointmentService;
    private readonly IRoomService _roomService;

    public HomeController(IDoctorService doctorService, IAppointmentService appointmentService, IRoomService roomService)
    {
      _doctorService = doctorService;
      _appointmentService = appointmentService;
      _roomService = roomService;
    }

    public IActionResult Index()
    {
      var homeViewModel = new HomeViewModel
      {
        Doctors = _doctorService.GetAllDoctors(1, 10).Data,
        UpcomingAppointments = _appointmentService.GetUpcomingAppointments(),
        AvailableRooms = _roomService.GetAvailableRooms()
      };

      return View(homeViewModel);
    }
  }
}
