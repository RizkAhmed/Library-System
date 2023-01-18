using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo5._1.Entities
{
    public abstract class Person
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
    public class Teacher:Person
    {
        public DateTime HireDate { get; set; }
    }
    public class Student : Person
    {
        public DateTime EnrolmentDate { get; set; }
    }
}
