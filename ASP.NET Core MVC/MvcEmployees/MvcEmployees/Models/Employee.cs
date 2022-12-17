using System.ComponentModel.DataAnnotations;

namespace MvcEmployees.Models;

public class Employee
{
    public int Id { get; set; }
    public string? EmployeeID { get; set; }
    public string? EmployeeName { get; set; }
    public string? Department { get; set; }
    public decimal Salary { get; set; }
}