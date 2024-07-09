using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
  public class Timing
  {
        public int Id { get; set; }

        public int MorningShiftStartTime { get; set; }


        public int MorningShiftEndTime { get; set; }

        public int AfternoonShiftStartTime { get; set; }


        public int AfternoonShiftEndTime { get; set; }


        public int Duration { get; set; }


        public Status Status { get; set; }


        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
    }

}

namespace Hospital.Models
{
  public enum Status
  {
    Dostępny,Aktywny
    }
}