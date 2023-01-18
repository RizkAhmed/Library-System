using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_AREA_VALIDATION.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Student name")]
        [Required(ErrorMessage ="Plese enter name")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Plese enter password")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Plese enter password")]
        [Compare("Password",ErrorMessage ="Password not matched")]
        public string ConfirmEmail { get; set; }

        public DateTime BirtDate { get; set; }
        [Required]
        public int Marks { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}