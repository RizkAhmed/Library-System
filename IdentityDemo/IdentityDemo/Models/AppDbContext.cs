using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentityDemo.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base("MyConn")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}