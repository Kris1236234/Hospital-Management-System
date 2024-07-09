using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class HomeViewModel
    {
        public List<DoctorViewModel> Doctors { get; set; }
        public List<AppointmentViewModel> UpcomingAppointments { get; set; }
        public List<RoomViewModel> AvailableRooms { get; set; }
      
    }
  
}