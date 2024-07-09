using Hospital.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital.ViewModels
{
  public class AppointmentViewModel
  {
    public int Id { get; set; }

    [Required]
    [Display(Name = "Numer wizyty")]
    public string Number { get; set; }

    [Required]
    [Display(Name = "Nazwa wizyty")]
    public string Name { get; set; }

    [Display(Name = "Status lekarza")]
    public string DoctorStatus { get; set; }

    [Required]
    [Display(Name = "Typ wizyty")]
    public string Type { get; set; }

    [Required]
    [Display(Name = "Czas wizyty")]
    [DataType(DataType.DateTime)]
    public DateTime AppointmentTime { get; set; }
    [Required]
    [Display(Name = "Czas wizyty")]
    [DataType(DataType.DateTime)]
    public DateTime AppointmentEndTime { get; set; }

    [Display(Name = "Data utworzenia")]
    [DataType(DataType.DateTime)]
    public DateTime CreatedDate { get; set; }

    [StringLength(500)]
    [Display(Name = "Opis wizyty")]
    public string Description { get; set; }

    [Required]
    [Display(Name = "Lekarz")]
    public int DoctorId { get; set; }

    [Required]
    [Display(Name = "Pacjent")]
    public int PatientId { get; set; }

    [Display(Name = "Imię i nazwisko pacjenta")]
    public string PatientName { get; set; }


    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }


        [Display(Name = "IDPokoju")]
        public int RoomId { get; set; }
    public Room Room { get; set; }

    public AppointmentViewModel()
    {
    }

    public AppointmentViewModel(Appointment app)
    {
      Id = app.Id;
      Number = app.Number;
      Name = app.Name;
      DoctorStatus = app.DoctorStatus;
      Type = app.Type;
      AppointmentTime = app.AppointmentTime;
      CreatedDate = app.CreatedDate;
      Description = app.Description;
      DoctorId = app.Doctor.Id;
      PatientId = app.Patient.Id;
    }

    public Appointment ConvertViewModelToModel()
    {
      return new Appointment
      {
        Id = this.Id,
        Number = this.Number,
        Name = this.Name,
        DoctorStatus = this.DoctorStatus,
        Type = this.Type,
        AppointmentTime = this.AppointmentTime,
        CreatedDate = this.CreatedDate,
        Description = this.Description,
        DoctorId = this.DoctorId,
        PatientId = this.PatientId,
        RoomId = this.RoomId

      };
    }
  }
}
