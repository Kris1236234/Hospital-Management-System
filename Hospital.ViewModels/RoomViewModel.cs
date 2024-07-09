using Hospital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hospital.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Numer pokoju jest wymagany.")]
        [Display(Name = "Numer Pokoju")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "Rodzaj pokoju jest wymagany.")]
        [Display(Name = "Rodzaj pokoju")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Status pokoju jest wymagany.")]
        [Display(Name = "Pozycja pokoju")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Wybór szpitala jest wymagany.")]
        [Display(Name = "Wybór Szpitala")]
        public int HospitalInfoId { get; set; }
        public HospitalInfo HospitalInfo { get; set; }

        [Display(Name = "Niedostępna sala")]
        public bool IsUnavailable { get; set; }


        public RoomViewModel()
        {

        }
        public RoomViewModel(Room r)

        {
            Id = r.Id;
            RoomNumber = r.RoomNumber;
            Type = r.Type;
            Status = r.Status;
            HospitalInfoId = r.HospitalId;
            HospitalInfo = r.Hospital;
            IsUnavailable = r.IsUnavailable;

        }


        public Room ConvertViewModelToModel()
        {
            return new Room
            {
                Id = this.Id,
                RoomNumber = this.RoomNumber,
                Type = this.Type,
                Status = this.Status,
                HospitalId = this.HospitalInfoId,
                IsUnavailable = this.IsUnavailable
            };
        }

    }
}
