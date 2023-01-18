using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCRUD.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }
      
        public ICollection<FavoriteBook> FavoriteBooks { get; set; }
        public IEnumerable<Book> Books { get; set; }


    }
}
