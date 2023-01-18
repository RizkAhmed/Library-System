using LibraryCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCRUD.ViewModels
{
    public class FavoriteBookViewModel
    {
        public int Id { get; set; }
        public List<Book> Books { get; set; }
    }
}
