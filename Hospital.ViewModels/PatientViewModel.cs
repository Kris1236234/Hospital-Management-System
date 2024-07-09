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
  public class PatientViewModel
    {
    public int Id { get; set; }
       

        [Display(Name = "Imie pacjenta")]
        [Required(ErrorMessage = "Pole 'Imię' jest wymagane.")]
        public string Imie { get; set; }
       
        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Pole 'Adres' jest wymagane.")]
        public string Adres { get; set; }
  
        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Pole 'Maisto' jest wymagane.")]
        public string Miasto { get; set; }

        [Required(ErrorMessage = "Pole 'PESEL' jest wymagane.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "PESEL musi składać się z 11 cyfr.")]
        public string PESEL { get; set; }


        public PatientViewModel() { }

    public PatientViewModel(Patient p)
    {
      Id = p.Id;
      Imie = p.Imie;
      Adres = p.Adres;
      Miasto = p.Miasto;
      PESEL = p.PESEL;

    }
  }
}
