using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo3.Entitis
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int? Age { get; set; }
        public string Adress { get; set; }
        public int YearOfHired { get; set; }
        public  Department Department { get; set; }
        public ICollection<TrainingCource> TrainingCources { get; set; } = new HashSet<TrainingCource>();

        //public override string ToString() => $"[{EmployeeID}] {Name}, {Age}, {Department.DepartmentID} ({Salary}) ";
    }
}
