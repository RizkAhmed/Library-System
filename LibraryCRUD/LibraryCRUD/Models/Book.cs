using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCRUD.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }   
        public int Year { get; set; }
        public float Rate { get; set; }
        [Required]
        [MaxLength(2500)]
        public string Description { get; set; }
        public byte[] Cover { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<FavoriteBook> FavoriteBooks { get; set; }
        public IEnumerable<UserAccount> UserAccounts { get; set; }

    }
}
