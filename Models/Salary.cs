using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
    internal class Salary : Employee
    {
        public void AverageSalary()
        {
            {
                using DatabaseProject context = new();
                // Calculate avarage and total salary of all the departments.
                var salary = context.Employees
                    .GroupBy(g => g.Department, g => g.Salary)
                    .Select(g => new
                    {
                        department = g.Key,
                        average = g.Average(),
                        total = g.Sum()

                    });

                Console.Clear();
                Console.WriteLine("-----------------------------------------\n" +
            "Snitt- och totallön för olika avdelningar\n" +
            "-----------------------------------------\n");
                Console.WriteLine("Avdelning".PadRight(15) + "Snittlön (kr/mån)".PadRight(20) + "Total lön (kr/mån)");
                Console.WriteLine("-----------------------------------------------------");
                // PRint out all different departments and the avarage och total salary each month.
                foreach (var row in salary)
                {
                    Console.WriteLine(row.department.PadRight(15) + Convert.ToString(decimal.Round(row.average, 2)).PadRight(20) + Convert.ToString(row.total));

                }
                Console.WriteLine("\nTryck Enter för att gå tillbaka...");
                Console.ReadLine();

            }
        }
    }
}
