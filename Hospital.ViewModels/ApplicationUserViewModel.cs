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
    public class ApplicationUserViewModel
    {

        [Required]
        [Display(Name = "Imie uzytkownika")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email uzytkownika")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Nazwa uzytkownika")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Miejscowość ")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Płeć")]
        public Gender Gender { get; set; }
      
        public bool IsDoctor { get; set; }
        [Required]
        [Display(Name = "Specjalizacja")]
        public string Specialist { get; set; }
        public object Id { get; set; }

        public ApplicationUserViewModel()
        {

        }
        public ApplicationUserViewModel(ApplicationUser a)
        {
            Name = a.Name;
            City = a.City;
            Gender = a.Gender;
            IsDoctor = a.IsDoctor;
            Specialist = a.Specialist;
            UserName = a.UserName;
            Email = a.Email;
            
        }
        public ApplicationUser ConvertViewModelToModel()
        {
            return new ApplicationUser
            {
                Name = this.Name,
                City = this.City,
                Gender = this.Gender,
                IsDoctor = this.IsDoctor,
                Specialist = this.Specialist,
                Email = this.Email,
                UserName = this.UserName
            };
        }

        
    }

}
