using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCRUD.Models
{
    public class FavoriteBook
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
