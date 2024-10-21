namespace EmployeeApp.Model
{
    public class Employee
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
    }
}