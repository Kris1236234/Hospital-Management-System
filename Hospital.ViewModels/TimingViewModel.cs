using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
  public class TimingViewModel
  {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Data Harmonogramu Dnia jest wymagane")]
        [Display(Name = "Data Harmonogramu Dnia")]
        public DateTime ScheduleDate { get; set; }

        [Required(ErrorMessage = "Pole Start Porannej Zmiany jest wymagane")]
        [Display(Name = "Start Porannej Zmiany")]
        public int MorningShiftStartTime { get; set; }

        [Required(ErrorMessage = "Pole Koniec Porannej Zmiany jest wymagane")]
        [Display(Name = "Koniec Porannej Zmiany")]
        public int MorningShiftEndTime { get; set; }

        [Required(ErrorMessage = "Pole Start Wieczornej Zmiany jest wymagane")]
        [Display(Name = "Start Wieczornej Zmiany")]
        public int AfternoonShiftStartTime { get; set; }

        [Required(ErrorMessage = "Pole Koniec Wieczornej Zmiany jest wymagane")]
        [Display(Name = "Koniec Wieczornej Zmiany")]
        public int AfternoonShiftEndTime { get; set; }

        [Required(ErrorMessage = "Pole Czas trwania jest wymagane")]
        [Display(Name = "Czas trwania")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Pole Pozycja dostępności jest wymagane")]
        [Display(Name = "Pozycja dostępności")]
        public Status Status { get; set; }

        [Required(ErrorMessage = "Pole Wybór lekarza jest wymagane")]
        [Display(Name = "Wybór lekarza")]
        public int DoctorId { get; set; }


        public Doctor Doctor { get; set; }


        public TimingViewModel()
    {

    }
    public TimingViewModel(Timing t)
    {
      Id = t.Id;
      ScheduleDate = t.Date;
      MorningShiftStartTime = t.MorningShiftStartTime;
      MorningShiftEndTime = t.MorningShiftEndTime;
      AfternoonShiftStartTime = t.AfternoonShiftStartTime;
      AfternoonShiftEndTime = t.AfternoonShiftEndTime;
      Duration = t.Duration;
      Status = t.Status;
      Doctor = t.Doctor;
      DoctorId = t.DoctorId;
        }
    public Timing ConvertViewModelToModel()
    {
      return new Timing
      {
        Id = this.Id,
        Date = this.ScheduleDate,
        MorningShiftStartTime = this.MorningShiftStartTime,
        MorningShiftEndTime = this.MorningShiftEndTime,
        AfternoonShiftStartTime = this.AfternoonShiftStartTime,
        AfternoonShiftEndTime = this.AfternoonShiftEndTime,
        Duration = this.Duration,
        Status = this.Status,
        DoctorId = this.DoctorId,
      };

    }


  }

}
