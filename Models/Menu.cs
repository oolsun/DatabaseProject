using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
    public class Menu
    {
        Employee employee = new();
        Student student = new();
        Grade grade = new();
        Salary salary = new();
        Subjects subjects = new();

        // Start menu where all choices are made.
        public void StartMenu()
        {
            string menuChoice = "";
            // While loop when navigating menu.
            while (menuChoice != "0")
            {
                // Print out all options.
                Console.Clear();
                Console.WriteLine("Hämta information från Hogwarts databas\n" +
                              "---------------------------------------\n" +
                              "1. Personal\n" +
                              "2. Elever\n" +
                              "3. Betyg\n" +
                              "4. Kurser\n" +
                              "5. Löner\n" +
                              "0. Avsluta program\n");

                Console.Write("Ditt val: ");
                menuChoice = Console.ReadLine();
                // Switch loop that takes user to the menu it chooses.
                switch (menuChoice)
                {
                    case "1":
                        EmployeeMenu();
                        break;
                    case "2":
                        StudentMenu();
                        break;
                    case "3":
                        GradeMenu();
                        break;
                    case "4":
                        subjects.AllSubjects();
                        break;
                    case "5":
                        salary.AverageSalary();
                        break;
                    case "0":
                        Console.Write("\nProgrammet avslutas\n");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("\nFelaktigt val! Vänligen försök igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void EmployeeMenu()
        {
            string menuChoice = "";
            // While loop when navigating menu.
            while (menuChoice != "0")
            {
                Console.Clear();
                Console.WriteLine("Hämta information från Hogwarts databas\n" +
                              "---------------------------------------\n" +
                              "Information om personal\n" +
                              "---------------------------------------\n" +
                              "1. Visa all personal\n" +
                              "2. Visa rektorer\n" +
                              "3. Visa lärare\n" +
                              "4. Visa all övrig personal\n" +
                              "5. Visa antal personal efter yrke\n" +
                              "6. Lägg till personal\n" +
                              "0. Återgå till föregående meny\n");
                Console.Write("Ditt val: ");
                menuChoice = Console.ReadLine();
                Console.Clear();

                // Switch loop that takes user to the menu it chooses.
                switch (menuChoice)
                {
                    case "1":
                        employee.AllEmployee();
                        Console.ReadKey();
                        break;
                    case "2":
                        employee.Headmaster();
                        Console.ReadKey();
                        break;
                    case "3":
                        employee.AllTeachers();
                        Console.ReadKey();
                        break;
                    case "4":
                        employee.AllOtherStaff();
                        Console.ReadKey();
                        break;
                    case "5":
                        employee.NumberOfEmployees();
                        Console.ReadKey();
                        break;
                    case "6":
                        employee.AddEmployees();
                        Console.ReadKey();
                        break;
                    case "0":
                        break;
                    default:
                        Console.Write("Felaktigt val! Vänligen försök igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void StudentMenu()
        {
            string menuChoice = "";
            // While loop when navigating menu.
            while (menuChoice != "0")
            {
                Console.Clear();
                Console.WriteLine("Hämta information från Hogwarts databas\n" +
                              "---------------------------------------\n" +
                              "Information om elever\n" +
                              "---------------------------------------\n" +
                              "1. Visa alla elever\n" +
                              "2. Visa elever i Gryffindor\n" +
                              "3. Visa elever i Slytherin\n" +
                              "4. Visa elever i Hufflepuff\n" +
                              "5. Visa elever i Ravenclaw\n" +
                              "6. Lägg till elev\n" +
                              "0. Återgå till föregående meny\n");
                Console.Write("Ditt val: ");
                menuChoice = Console.ReadLine();
                Console.Clear();

                // Switch loop that takes user to the menu it chooses.
                switch (menuChoice)
                {
                    case "1":
                        student.AllStudents();
                        break;
                    case "2":
                        student.StudentsInClass("Gryffindor");
                        Console.ReadKey();
                        break;
                    case "3":
                        student.StudentsInClass("Slytherin");
                        Console.ReadKey();
                        break;
                    case "4":
                        student.StudentsInClass("Hufflepuff");
                        Console.ReadKey();
                        break;
                    case "5":
                        student.StudentsInClass("Ravenclaw");
                        Console.ReadKey();
                        break;
                    case "6":
                        student.AddStudents();
                        Console.ReadKey();
                        break;
                    case "0":
                        break;
                    default:
                        Console.Write("Felaktigt val! Vänligen försök igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void GradeMenu()
        {
            string menuChoice = "";
            // While loop when navigating menu.
            while (menuChoice != "0")
            {
                Console.Clear();
                Console.WriteLine("Hämta information från Hogwarts databas\n" +
                              "---------------------------------------\n" +
                              "Information om betyg\n" +
                              "---------------------------------------\n" +
                              "1. Visa alla betyg\n" +
                              "2. Visa alla betyg senaste månaden\n" +
                              "3. Visa snittbetyg på alla kurser\n" +
                              "4. Sätt betyg\n" +
                              "5. Ändra betyg\n" +
                              "0. Återgå till föregående meny\n");
                Console.Write("Ditt val: ");
                menuChoice = Console.ReadLine();
                Console.Clear();

                // Switch loop that takes user to the menu it chooses.
                switch (menuChoice)
                {
                    case "1":
                        grade.AllGrades();
                        break;
                    case "2":
                        grade.LastMonthsGrades();
                        break;
                    case "3":
                        grade.AverageGrade();
                        break;
                    case "4":
                        grade.AddGrades();
                        break;
                    case "5":
                        grade.UpdateGrades();
                        break;
                    case "0":
                        break;
                    default:
                        Console.Write("Felaktigt val! Vänligen försök igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
