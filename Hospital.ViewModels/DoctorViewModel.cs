using Hospital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    
        public class DoctorViewModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Pole Imię jest wymagane")]
            [Display(Name = "Imię")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Pole Nazwisko jest wymagane")]
            [Display(Name = "Nazwisko")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Pole Specjalizacja jest wymagane")]
            [Display(Name = "Specjalizacja")]
            public string Specialization { get; set; }

            [Required(ErrorMessage = "Pole Numer PWZ jest wymagane")]
            [StringLength(7, MinimumLength = 7, ErrorMessage = "Numer PWZ musi mieć 7 znaków.")]
            [Display(Name = "Numer PWZ")]
            public string PWZNumber { get; set; }

        [Display(Name = "Sortuj według")]
        public string SortBy { get; set; }





        public DoctorViewModel()
    { }

    public DoctorViewModel(Doctor d)
    {
      Id = d.Id;
      Name = d.Name;
      LastName = d.LastName;
      Specialization = d.Specialization;
      PWZNumber = d.PWZNumber;

    }

    public static Doctor ConvertViewModel(DoctorViewModel vm)
    {
      return new Doctor()
      {
        Id = vm.Id,
        Name = vm.Name,
        LastName = vm.LastName,
        Specialization = vm.Specialization,
        PWZNumber = vm.PWZNumber,

        };
    }
  }

}
