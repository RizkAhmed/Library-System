using Demo5._1.Context;
using Demo5._1.Entities;
using System;

namespace Demo5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                context.Add(new Teacher { Name = "rizk", HireDate = new DateTime(2010, 1, 5) });
                context.Add(new Student { Name = "hossam", EnrolmentDate = new DateTime(2018, 7, 4) });
                context.Add(new Teacher { Name = "ramy", HireDate = new DateTime(2011, 9, 2) });
                context.Add(new Student { Name = "ahmed", EnrolmentDate = new DateTime(2018, 8, 4) });
                context.SaveChanges();

                foreach (var teacher in context.Teachers)
                {
                    Console.WriteLine($" [{teacher.ID}] {teacher.Name} ({teacher.HireDate})");
                }
                foreach (var student in context.Students)
                {
                    Console.WriteLine($" [{student.ID}] {student.Name} ({student.EnrolmentDate})");
                }
                Console.ReadLine();
            }
        }
    }
}
