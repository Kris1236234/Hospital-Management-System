using Hospital.ViewModels;
using hospitals.Utilities;
using System.Collections.Generic;

namespace Hospital.Services
{
  public interface IAppointmentService
  {
    List<AppointmentViewModel> GetUpcomingAppointments();
    AppointmentViewModel GetAppointmentById(int appointmentId);
    void CreateAppointment(AppointmentViewModel appointment);
    void UpdateAppointment(AppointmentViewModel appointment);
    void DeleteAppointment(int appointmentId);
    PagedResult<AppointmentViewModel> GetAll(int pageNumber, int pageSize);
  }
}
