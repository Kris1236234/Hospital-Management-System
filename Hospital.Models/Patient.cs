using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole 'Imię' jest wymagane.")]
        public string? Imie { get; set; }

        public string? Adres { get; set; }
        public string? Miasto { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "PESEL musi składać się z 11 cyfr.")]
        public string PESEL { get; set; }
    }
}

