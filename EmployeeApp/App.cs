using EmployeeApp.Database;
using EmployeeApp.Model;

namespace EmployeeApp;

public class App(AppDbContext dbContext)
{
    public void Run()
    {
        Console.WriteLine("1. - Add Employee\n2. - Get Employees");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddEmployee();
                break;
            case "2":
                GetEmployees();
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }

    private void AddEmployee()
    {
        Console.Write("Enter Name: ");
        var name = Console.ReadLine();

        Console.Write("Enter Position: ");
        var position = Console.ReadLine();

        Console.Write("Enter Salary: ");
        if (decimal.TryParse(Console.ReadLine(), out var salary))
        {
            if (position != null && name != null)
            {
                    var employee = new Employee
                    {
                        Name = name,
                        Position = position,
                        Salary = salary
                    };
                    dbContext.Employees.Add(employee);
            }

            dbContext.SaveChanges();
            Console.WriteLine("Employee added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid salary input.");
        }
    }

    private void GetEmployees()
    {
        var employees = dbContext.Employees.ToList();
        if (employees.Count != 0)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Id}: {employee.Name}, {employee.Position}, {employee.Salary:C}");
            }
        }
        else
        {
            Console.WriteLine("No employees found.");
        }
    }
}