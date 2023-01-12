using LibraryCRUD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCRUD.ViewModels
{
    public class BookFormViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Display(Name = "Year of Publication")]
        public int Year { get; set; }
        [Range(1,10)]
        public float Rate { get; set; }
        [Required]
        [StringLength(2500)]
        public string Description { get; set; }
        [Display(Name = "Select Cover...")]
        public byte[] Cover { get; set; }
        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
