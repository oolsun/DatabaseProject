using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DatabaseProject.Models;

public partial class Grade
{
    public int FkemployeeId { get; set; }

    public int FkstudentId { get; set; }

    public int Grade1 { get; set; }

    public DateTime GradeDate { get; set; }

    public int GradeId { get; set; }

    public virtual Employee Fkemployee { get; set; } = null!;

    public virtual Student Fkstudent { get; set; } = null!;

    public void LastMonthsGrades()
    {
        using DatabaseProject context = new();

        // Include foreign keys and choose to show all rows with gradedates last month. Sort by grade date.
        var grades = context.Grades
            .Include(b => b.Fkemployee)
            .Include(b => b.Fkstudent)
            .Where(b => b.GradeDate <= DateTime.Today)
            .Where(b => b.GradeDate >= DateTime.Today.AddMonths(-1))
            .OrderBy(b => b.GradeDate);

        Console.Clear();
        Console.WriteLine("---------------------\n" +
            "Betyg senaste månaden\n" +
            "---------------------\n");
        Console.WriteLine("Lärare".PadRight(27) + "Elev".PadRight(25) + "Ämne".PadRight(35) + "Betyg".PadRight(15) + "Betygsdatum");
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
        // Foreach to show all grades in last 30 days. 
        foreach (var row in grades)
        {
            Console.WriteLine(row.Fkemployee.FirstName.PadRight(11) + " " + row.Fkemployee.LastName.PadRight(15) +
                row.Fkstudent.FirstName.PadRight(9) + " " + row.Fkstudent.LastName.PadRight(15) +
                row.Fkemployee.Subject.PadRight(35) + row.Grade1 + "".PadRight(14) + row.GradeDate.ToString("yyyy-MM-dd"));
        }

        Console.WriteLine("\nTryck Enter för att gå tillbaka...");
        Console.ReadLine();

    }

    public void AverageGrade()
    {
        using DatabaseProject context = new();
                
        // Group all subjects and grades to show average, max and min grade of each subject.
        var grades = context.Grades
            .Include(g => g.Fkemployee)
            .GroupBy(g => g.Fkemployee.Subject, g => g.Grade1)
            .Select(g => new
            {
                Subject = g.Key,
                Average = g.Average(),
                Highest = g.Max(),
                Lowest = g.Min()
            });

        Console.Clear();
        Console.WriteLine("----------------------\n" +
    "Kurser och snittbetyg\n" +
    "----------------------\n");
        Console.WriteLine("Kurs".PadRight(30) + "Snittbetyg".PadRight(15) + "Högst betyg".PadRight(15) + "Lägst betyg");
        Console.WriteLine("-----------------------------------------------------------------------");
        // Foreach to print all subjects with average, max and min grade. Converted all grades to string so I could use PadRight for design purpose.
        foreach (var grade in grades)
        {
            Console.WriteLine(grade.Subject.PadRight(30) + Convert.ToString(grade.Average).PadRight(15) + Convert.ToString(grade.Highest).PadRight(15) + grade.Lowest);
        }

        Console.WriteLine("\nTryck Enter för att gå tillbaka...");
        Console.ReadLine();
    }

    public void AllGrades()
    {
        using DatabaseProject context = new();

        // Include foreign keys and sort by students first name.
        var grades = context.Grades
            .Include(b => b.Fkemployee)
            .Include(b => b.Fkstudent)
            .OrderBy(b => b.Fkstudent.FirstName);

        Console.Clear();
        Console.WriteLine("---------------------\n" +
            "Alla betyg\n" +
            "---------------------\n");
        Console.WriteLine("Lärare".PadRight(27) + "Elev".PadRight(25) + "Ämne".PadRight(35) + "Betyg".PadRight(15) + "Betygsdatum");
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
        // Foreach to show all grades for each student. 
        foreach (var row in grades)
        {
            Console.WriteLine(row.Fkemployee.FirstName.PadRight(11) + " " + row.Fkemployee.LastName.PadRight(15) +
                row.Fkstudent.FirstName.PadRight(9) + " " + row.Fkstudent.LastName.PadRight(15) +
                row.Fkemployee.Subject.PadRight(35) + row.Grade1 + "".PadRight(14) + row.GradeDate.ToString("yyyy-MM-dd"));
        }

        Console.WriteLine("\nTryck Enter för att gå tillbaka...");
        Console.ReadLine();

    }

    public void UpdateGrades()
    {
        using DatabaseProject context = new();
        // Show all students.
        var students = context.Students
                        .OrderBy(b => b.StudentId);

        Console.Clear();
        Console.WriteLine("---------------\n" +
            "Uppdatera betyg\n" +
            "---------------\n");

        Console.WriteLine("ID".PadRight(5) + "Förnamn".PadRight(15) + "Efternamn".PadRight(15) + "Klass");
        Console.WriteLine("----------------------------------------");
        foreach (var row in students)
        {
            Console.WriteLine(Convert.ToString(row.StudentId).PadRight(5) + row.FirstName.PadRight(15) + row.LastName.PadRight(15) + row.Class);
        }
        // Choose student.
        Console.WriteLine("\nVälj elev-ID: ");
        int chooseStudent = Convert.ToInt32(Console.ReadLine());
        // Show all grades that student have.
        var subject = context.Grades
            .Include(b => b.Fkemployee)
            .Include(b => b.Fkstudent)
            .Where(b => b.FkstudentId == chooseStudent)
            .OrderBy(b => b.Fkemployee.EmployeeId);

        Console.Clear();
        Console.WriteLine("------------------------\n" +
            "Alla betyg för vald elev\n" +
            "------------------------\n");
        Console.WriteLine("ID".PadRight(5) + "Lärare".PadRight(26) + "Elev".PadRight(25) + "Ämne".PadRight(35) + "Betyg".PadRight(15) + "Betygsdatum");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

        foreach (var row in subject)
        {
            Console.WriteLine(Convert.ToString(row.GradeId).PadRight(5) + row.Fkemployee.FirstName.PadRight(11) + row.Fkemployee.LastName.PadRight(15) +
                row.Fkstudent.FirstName.PadRight(9) + " " + row.Fkstudent.LastName.PadRight(15) +
                row.Fkemployee.Subject.PadRight(35) + row.Grade1 + "".PadRight(14) + row.GradeDate.ToString("yyyy-MM-dd"));
        }
        // Choose what grade to upgrade.
        Console.WriteLine("\nVälj betygs-ID");
        int chooseTeacher = Convert.ToInt32(Console.ReadLine());
        // Set new grade
        int setGrade;
        while (true)
        {
            Console.WriteLine("Sätt betyg (1-5)");
            setGrade = Convert.ToInt16(Console.ReadLine());
            if (setGrade > 0 && setGrade <= 5)
            {
                break;
            }
            else
            {
                Console.WriteLine("Felaktigt betyg. Betyget måste vara mellan 1-5.");
            }
        }
        // Use user inputs to update grades.
        var updateGrade = context.Grades
            .Where(g => g.FkstudentId == chooseStudent)
            .Where(g => g.FkemployeeId == chooseTeacher)
            .FirstOrDefault();
        if (updateGrade != null)
        {
            updateGrade.Grade1 = setGrade;
            updateGrade.GradeDate = DateTime.Now;
            context.SaveChanges();
            Console.WriteLine("\nBetyget uppdaterat");
        }
        else
        {
            Console.WriteLine("Kunde inte uppdatera betyg...");
        }
        Console.WriteLine("\nTryck Enter för att gå vidare...");
        Console.ReadLine();

    }

    public void AddGrades()
    {
        using DatabaseProject context = new();
        // Show all students.
        var students = context.Students
                        .OrderBy(b => b.StudentId);

        Console.Clear();
        Console.WriteLine("---------------\n" +
            "Sätt nytt betyg\n" +
            "---------------\n");

        Console.WriteLine("ID".PadRight(5) + "Förnamn".PadRight(15) + "Efternamn".PadRight(15) + "Klass");
        Console.WriteLine("----------------------------------------");
        foreach (var row in students)
        {
            Console.WriteLine(Convert.ToString(row.StudentId).PadRight(5) + row.FirstName.PadRight(15) + row.LastName.PadRight(15) + row.Class);
        }
        // Choose student.
        Console.WriteLine("\nVälj elev-ID: ");
        int chooseStudent = Convert.ToInt32(Console.ReadLine());

        // Show all subject with its teachers.
        var subject = context.Employees            
            .Where(b => b.Department == "Teacher")
            .OrderBy(b => b.EmployeeId);

        Console.Clear();
        Console.WriteLine("------------------------\n" +
            "Välj ämne\n" +
            "------------------------\n");
        Console.WriteLine("ID".PadRight(5) + "Lärare".PadRight(26) + "Ämne");
        Console.WriteLine("--------------------------------------------------------");

        foreach (var row in subject)
        {
            Console.WriteLine(Convert.ToString(row.EmployeeId).PadRight(5) + row.FirstName.PadRight(11) + row.LastName.PadRight(15) + row.Subject);
        }
        // Choose what grade to upgrade.
        Console.WriteLine("\nVälj lärar-ID");
        int chooseTeacher = Convert.ToInt32(Console.ReadLine());
        // Set new grade
        int setGrade;
        while (true)
        {
            Console.WriteLine("Sätt betyg (1-5)");
            setGrade = Convert.ToInt16(Console.ReadLine());
            if (setGrade > 0 && setGrade <= 5)
            {
                break;
            }
            else
            {
                Console.WriteLine("Felaktigt betyg. Betyget måste vara mellan 1-5.");
            }
        }
        // Use user inputs to add grade.
        var addGrade = new Grade()
        {
            FkemployeeId = chooseTeacher,
            FkstudentId = chooseStudent,
            Grade1 = setGrade,
            GradeDate = DateTime.Now

        };
        // Adding and saving the new grade.
        context.Grades.Add(addGrade);
        context.SaveChanges();
        Console.WriteLine("\nBetyg satt!");
        Console.WriteLine("\nTryck Enter för att gå vidare...");
        Console.ReadLine();

    }
}
