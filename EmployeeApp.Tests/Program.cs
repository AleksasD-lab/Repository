using EmployeeApp.Database;
using EmployeeApp.Model;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EmployeeApp.Tests;

public class AppTests : IDisposable
{
    private readonly AppDbContext _dbContext;

    public AppTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;
        _dbContext = new AppDbContext(options);
    }

    [Fact]
    public void AddEmployee_ShouldAddEmployee()
    {
        var employee = new Employee { Name = "Test Employee", Position = "Developer", Salary = 60000 };

        _dbContext.Employees.Add(employee);
        _dbContext.SaveChanges();

        Assert.Equal(1, _dbContext.Employees.Count());
    }

    [Fact]
    public void GetEmployees_ShouldReturnEmployees()
    {
        _dbContext.Employees.Add(new Employee { Name = "Employee 1", Position = "Manager", Salary = 80000 });
        _dbContext.Employees.Add(new Employee { Name = "Employee 2", Position = "Developer", Salary = 70000 });
        _dbContext.SaveChanges();

        var employees = _dbContext.Employees.ToList();

        Assert.Equal(2, employees.Count);
    }
    
    public void Dispose()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Dispose();
    }
}