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
    public class ContactViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole Email jest wymagane")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole Telefon jest wymagane")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Pole Wybór szpitala jest wymagane")]
        [Display(Name = "Wybór szpitala")]
        public int HospitalInfoId { get; set; }

        public HospitalInfo HospitalInfo { get; set; }


        public ContactViewModel()
        {

        }
        public ContactViewModel(Contact c)

        {
            Id = c.Id;
            Email = c.Email;
            Phone = c.Phone;
            HospitalInfoId = c.HospitalId;
            HospitalInfo = c.Hospital;

        }
        public Contact ConvertViewModel(ContactViewModel vm)

        {
            return new Contact
            {
                Id = vm.Id,
                Email = vm.Email,
                Phone = vm.Phone,
                HospitalId = vm.HospitalInfoId,
                Hospital = vm.HospitalInfo


            };

        }

        public Contact ConvertViewModelToModel()
        {
            return new Contact
            {
                Id = Id,
                Email = Email,
                Phone = Phone,
                HospitalId = HospitalInfoId,
                Hospital = HospitalInfo
            };
        }

    }
}
