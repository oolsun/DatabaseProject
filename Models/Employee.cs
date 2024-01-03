using System;
using System.Collections.Generic;

namespace DatabaseProject.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Title { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Subject { get; set; }

    public DateTime EmploymentDate { get; set; }

    public decimal Salary { get; set; }

    public string Department { get; set; } = null!;

    public void AllEmployee()
    {
        using DatabaseProject context = new();


        // Foreach to print out all employees in database. Using PadRight for design purposes.
        Console.WriteLine("Titel".PadRight(15) + "Förnamn".PadRight(15) + "Efternamn".PadRight(15) + "Anställd antal år");
        Console.WriteLine("--------------------------------------------------------------");
        foreach (var row in context.Employees)
        {
            Console.WriteLine(row.Title.PadRight(15) + row.FirstName.PadRight(15) + row.LastName.PadRight(23) + (DateTime.Today.Year - row.EmploymentDate.Year));
        }
        Console.WriteLine("\nTryck Enter för att gå tillbaka...");
    }

    public void AllTeachers()
    {
        using DatabaseProject context = new();
        // Choose to only show "Teacher" from database.
        var employees = context.Employees
                                .Where(p => p.Department == "Teacher");

        // Foreach to print out all Teachers in database. Using PadRight for design purposes.
        Console.WriteLine("Titel".PadRight(15) + "Förnamn".PadRight(15) + "Efternamn");
        Console.WriteLine("------------------------------------------------");
        foreach (var row in employees)
        {
            Console.WriteLine(row.Title.PadRight(15) + row.FirstName.PadRight(15) + row.LastName);
        }
        Console.WriteLine("\nTryck Enter för att gå tillbaka...");
    }

    public void Headmaster()
    {
        using DatabaseProject context = new();
        // Choose to only show "Headmaster" from database.
        var employees = context.Employees
                                .Where(p => p.Department == "Principal");

        // Foreach to print out all Headmasters in database. Using PadRight for design purposes.
        Console.WriteLine("Titel".PadRight(15) + "Förnamn".PadRight(15) + "Efternamn");
        Console.WriteLine("------------------------------------------------");
        foreach (var row in employees)
        {
            Console.WriteLine(row.Title.PadRight(15) + row.FirstName.PadRight(15) + row.LastName);
        }
        Console.WriteLine("\nTryck Enter för att gå tillbaka...");
    }

    public void AllOtherStaff()
    {
        using DatabaseProject context = new();
        // Choose to show all that isnt "Headmaster" or "Teacher" from database.
        var employees = context.Employees
                                .Where(p => p.Department != "Principal" && p.Department != "Teacher");

        // Foreach to print out all employee that isnt Teacher or Headmaster in database. Using PadRight for design purposes.
        Console.WriteLine("Titel".PadRight(20) + "Förnamn".PadRight(15) + "Efternamn");
        Console.WriteLine("------------------------------------------------");
        foreach (var row in employees)
        {
            Console.WriteLine(row.Title.PadRight(20) + row.FirstName.PadRight(15) + row.LastName);
        }
        Console.WriteLine("\nTryck Enter för att gå tillbaka...");
    }

    public void NumberOfEmployees()
    {
        using DatabaseProject context = new();

        var employeeCount = context.Employees
                                    .GroupBy(x => x.Department)
                                    .Select(x => new
                                    {
                                        title = x.Key,
                                        count = x.Count()
                                    });

        Console.WriteLine("Yrke".PadRight(15) + "Antal");
        Console.WriteLine("--------------------");
        foreach (var row in employeeCount)
        {

            Console.WriteLine(row.title.PadRight(15) + row.count);
        }
        Console.WriteLine("\nTryck Enter för att gå tillbaka...");
    }

    public void AddEmployees()
    {
        using DatabaseProject context = new();
        Console.Clear();

        // Adding employees to database.
        Console.WriteLine("Lägg till personal\n");
        Console.Write("Förnamn: ");
        string firstName = Console.ReadLine();
        Console.Write("Efternamn: ");
        string lastName = Console.ReadLine();
        Console.Write("Lön: ");
        decimal salary = Convert.ToDecimal(Console.ReadLine());

        string title = "";

        string menuChoice = "";
        // Give the user option to quick choose teacher, or else type their own title.
        while (title == "")
        {
            Console.WriteLine("Välj yrke\n" +
                "1. Lärare\n" +
                "2. Övrig personal\n");

            Console.Write("Yrkestitel (engelska): ");
            menuChoice = Console.ReadLine();
            Console.Clear();

            switch (menuChoice)
            {
                case "1":
                    title = "Teacher";
                    break;
                case "2":
                    title = Console.ReadLine();
                    break;
                default:
                    Console.Write("Felaktigt val! Vänligen försök igen.");
                    Console.ReadKey();
                    break;
            }
        }
        
        string subject;
        string department;

        if (title == "Teacher")
        {
            Console.WriteLine("Ange ämne (engelska)");
            subject = Console.ReadLine();
            department = "Teacher";
        }
        else
        {
            subject = null;
            department = "Other";
        }
        // Adding user inputs to new employee.
        var addEmployee = new Employee()
        {
            FirstName = firstName,
            LastName = lastName,
            Title = title,
            Subject = subject,
            Salary = salary,
            EmploymentDate = DateTime.Today,
            Department = department
        };

        // Adding and saving the new employee.
        context.Employees.Add(addEmployee);
        context.SaveChanges();

        // Give user a confirmation of new employee added.
        Console.WriteLine("Du har lagt till " + firstName + " " + lastName + " som " + title + "!");
        Console.ReadLine();
    }
}
