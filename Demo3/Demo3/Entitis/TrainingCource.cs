using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo3.Entitis
{
    public class TrainingCource
    {
        public int CourceID { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string CourseURL { get; set; }
        public string BeginDate { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
