using System;
using System.Collections.Generic;

namespace DatabaseProject.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string SocialSecurityNumber { get; set; } = null!;

    public string Class { get; set; } = null!;

    public void AllStudents()
    {
        string menuChoice = "";

        // Stay in loop until user input is 0.
        while (menuChoice != "0")
        {
            using DatabaseProject context = new();

            var query = context.Students;
            var order = query.OrderBy(x => x.FirstName);

            // Give user the option to choose how to sort the students.
            Console.WriteLine("--------------\n" +
                "Sortera elever\n" +
                "--------------\n" +
                "1. Förnamn (stigande)\n" +
                "2. Förnamn (fallande)\n" +
                "3. Efternamn (stigande)\n" +
                "4. Efternamn (fallande)\n" +
                "0. Återgå till föregående meny\n");

            Console.Write("Ditt val: ");
            menuChoice = Console.ReadLine();
            Console.Clear();

            switch (menuChoice)
            {
                // If user choose 1, students are sorted by first name, ascending.
                case "1":
                    order = query.OrderBy(x => x.FirstName);
                    break;
                // If user choose 2, students are sorted by first name, descending.
                case "2":
                    order = query.OrderByDescending(x => x.FirstName);
                    break;
                // If user choose 3, students are sorted by last name, ascending.
                case "3":
                    order = query.OrderBy(x => x.LastName);
                    break;
                // If user choose 4, students are sorted by last name, descending.
                case "4":
                    order = query.OrderByDescending(x => x.LastName);
                    break;
                // If user choose 0, they go back to previous menu.
                case "0":
                    break;
                default:
                    Console.Write("Felaktigt val! Vänligen försök igen.");
                    Console.ReadKey();
                    break;
            }

            if (menuChoice == "0")
            {
                // User go back to previous menu.
            }
            else
            {
                Console.WriteLine("Förnamn".PadRight(15) + "Efternamn".PadRight(15) + "Klass".PadRight(15) + "Personnummer");
                Console.WriteLine("------------------------------------------------------------");
                foreach (var row in order)
                {
                    Console.WriteLine(row.FirstName.PadRight(15) + row.LastName.PadRight(15) + row.Class.PadRight(15) + row.SocialSecurityNumber);
                }
                Console.WriteLine();
            }
        }

    }

    public void StudentsInClass(string classInput)
    {
        using DatabaseProject context = new();
        // Give currentClass the class that user choose in previous menu.
        string currentClass = classInput;

        var query = context.Students;
        // Print out all students in the class user choose in previuous menu.   
        Console.WriteLine("Förnamn".PadRight(15) + "Efternamn".PadRight(15) + "Klass".PadRight(15) + "Personnummer");
        Console.WriteLine("------------------------------------------------------------");
        foreach (var row in query)
        {
            if (row.Class == currentClass)
            {
                Console.WriteLine(row.FirstName.PadRight(15) + row.LastName.PadRight(15) + row.Class.PadRight(15) + row.SocialSecurityNumber);
            }
            else
            {

            }
        }
        Console.WriteLine("\nTryck Enter för att gå tillbaka...");
    }

    public void AddStudents()
    {
        using DatabaseProject context = new();
        Console.Clear();

        // Adding new student.
        Console.WriteLine("Lägg till elev\n");
        Console.Write("Förnamn: ");
        string firstName = Console.ReadLine();
        Console.Write("Efternamn: ");
        string lastName = Console.ReadLine();
        Console.Write("Personnummer (YYYY-MM-DD-XXXX): ");
        string socialSecurityNumber = Console.ReadLine();

        string studentClass = "";

        string menuChoice = "";

        // Give user the option to choose class, so it wont be misspelled or some other error.
        while (studentClass == "")
        {
            Console.WriteLine("Välj klass\n" +
                "1. Gryffindor\n" +
                "2. Slytherin\n" +
                "3. Hufflepuff\n" +
                "4. Ravenclaw\n");

            Console.Write("Ditt val: ");
            menuChoice = Console.ReadLine();
            Console.Clear();

            switch (menuChoice)
            {
                case "1":
                    studentClass = "Gryffindor";
                    break;
                case "2":
                    studentClass = "Slytherin";
                    break;
                case "3":
                    studentClass = "Hufflepuff";
                    break;
                case "4":
                    studentClass = "Ravenclaw";
                    break;
                default:
                    Console.Write("Felaktigt val! Vänligen försök igen.");
                    Console.ReadKey();
                    break;
            }
        }

        // Adding user input to new student.
        var addStudent = new Student()
        {
            FirstName = firstName,
            LastName = lastName,
            SocialSecurityNumber = socialSecurityNumber,
            Class = studentClass
        };

        // Adding new student to database and save.
        context.Students.Add(addStudent);
        context.SaveChanges();

        // Give user confirmation of added student.
        Console.WriteLine("Du har lagt till " + firstName + " " + lastName + " i " + studentClass + "!");
        Console.ReadLine();
    }
}
