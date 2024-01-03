using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
    internal class Subjects : Employee
    {
        public void AllSubjects()
        {
            using DatabaseProject context = new();

            Console.Clear();
            Console.WriteLine("Alla kurser".PadRight(35) + "Lärare");
            Console.WriteLine("--------------------------------------------------------");
            // Print out all employees and the subjects they teach in.
            foreach (var row in context.Employees)
            {
                if (row.Subject == null)
                {

                }
                else
                {
                    Console.WriteLine(row.Subject.PadRight(35) + row.FirstName.PadRight(15) + row.LastName);
                }
            }
            Console.WriteLine("\nTryck Enter för att gå tillbaka...");
            Console.ReadLine();
        }
    }
}
