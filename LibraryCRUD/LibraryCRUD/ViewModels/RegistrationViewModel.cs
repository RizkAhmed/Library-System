using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreIdentity.ViewModels
{
    public class RegistrationViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="User name")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [Display(Name ="Confirm password")]
        public string ConfirmPassword { get; set; }

    }
}
