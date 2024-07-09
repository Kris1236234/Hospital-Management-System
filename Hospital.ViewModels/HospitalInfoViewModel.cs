using Hospital.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital.ViewModels
{
    public class HospitalInfoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole 'Nazwa' jest wymagane.")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole 'Rodzaj' jest wymagane.")]
        [Display(Name = "Rodzaj")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Pole 'Miasto' jest wymagane.")]
        [RegularExpression(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s-]+$", ErrorMessage = "Wprowadź poprawne miasto.")]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Required(ErrorMessage = "Pole 'Kod pocztowy' jest wymagane.")]
        [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Wprowadź poprawny format kodu pocztowego (XX-XXX).")]
        [Display(Name = "Kod pocztowy")]
        public string PinCode { get; set; }

        [Required(ErrorMessage = "Pole 'Kraj' jest wymagane.")]
        [RegularExpression(@"^[a-zA-Z\s-]+$", ErrorMessage = "Wprowadź poprawny kraj.")]
        [Display(Name = "Kraj")]
        public string Country { get; set; }

        public HospitalInfoViewModel()
        {

        }

        public HospitalInfoViewModel(HospitalInfo h)
        {
            Id = h.Id;
            Name = h.Name;
            Type = h.Type;
            City = h.City;
            PinCode = h.PinCode;
            Country = h.Country;
        }

      
        public HospitalInfo ConvertViewModel()
        {
            return new HospitalInfo
            {
                Id = this.Id,
                Name = this.Name,
                Type = this.Type,
                City = this.City,
                PinCode = this.PinCode,
                Country = this.Country
            };
        }
    }
}
