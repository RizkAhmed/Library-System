using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo3.Entitis
{
    public class Department
    {
        public int DepartmentID { get; set; }
                public string Name { get; set; }
        public  ICollection<Employee> Employees { get; set; }
        public Department()
        {
            Employees = new HashSet<Employee>();
        } 
    }
}
