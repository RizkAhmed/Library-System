using LibraryCRUD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCRUD.ViewModels
{
    public class AuthorFormViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }

        [Required]
        [StringLength(2500)]
        public string Description { get; set; }

        [Display(Name = "Select image...")]
        public byte[] Image { get; set; }
        public IEnumerable<Book> Books { get; set; }

    }
}
