using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCRUD.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        [Required]
        [MaxLength(2500)]
        public string Description { get; set; }
        public byte[] Image { get; set; }

    }
}
