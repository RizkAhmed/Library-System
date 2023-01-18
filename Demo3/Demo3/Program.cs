using Demo3.Context;
using Demo3.Entitis;
using System.Linq;
using System;

namespace Demo3
{
    class Program
    {
        static void Main(string[] args)
        {
           
           
            using (var context = new EntetPriceContext())
            {
                context.Database.EnsureCreated();

                var d1 = new Department
                {
                    Name="programing",
                };
                var d2 = new Department
                {
                    Name = "network",
                };

                var s1 = new TrainingCource
                {
                    Title = "c#",
                    Duration = 80,
                };
                var s2 = new TrainingCource
                {
                    Title = "c++",
                    Duration = 60,
                }; var s3 = new TrainingCource
                {
                    Title = "java",
                    Duration = 85,
                };
                
                var e1 = new Employee
                {
                    Name = "mohamed",
                    Salary = 5000,
                };
                var e2 = new Employee
                {
                    Name = "hema",
                    Salary = 6000,
                };
                var e3 = new Employee
                {
                    Name = "osama",
                    Salary = 6500,
                };
                var e4 = new Employee
                {
                    Name = "nwaf",
                    Salary = 6000,
                };
                e1.Department=d1;
                e2.Department = d2;
                e3.Department = d1;
                e4.Department = d2;

                e1.TrainingCources.Add(s1);
                e1.TrainingCources.Add(s3);
                e2.TrainingCources.Add(s2);
                e2.TrainingCources.Add(s3);
                e3.TrainingCources.Add(s1);
                e3.TrainingCources.Add(s2);
                e4.TrainingCources.Add(s1);
                e4.TrainingCources.Add(s3);

                context.AddRange(new Department[] { d1,d2});
                context.AddRange(new TrainingCource[] { s1, s2, s3 });
                context.AddRange(new Employee[] { e1, e2, e3, e4 });
                context.SaveChanges();
                Console.WriteLine("done");

            }
        }
    }
}
