using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcEmployees.Data;
using System;
using System.Linq;

namespace MvcEmployees.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcEmployeesContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcEmployeesContext>>()))
        {
            // Look for any Employeess.
            if (context.Employee.Any())
            {
                return;   // DB has been seeded
            }
            context.Employee.AddRange(
                new Employee
                {
                    EmployeeID = "EM001",
                    EmployeeName = "Jonh Carter",
                    Department = "HR",
                    Salary = 3000
                },
                new Employee
                {
                    EmployeeID = "EM002",
                    EmployeeName = "Michael Bean",
                    Department = "SC",
                    Salary = 1300
                },
                 new Employee
                 {
                     EmployeeID = "EM003",
                     EmployeeName = "Jimmy Floy",
                     Department = "MD",
                     Salary = 2000
                 },
                 new Employee
                 {
                     EmployeeID = "EM004",
                     EmployeeName = "Mary Brown",
                     Department = "MD",
                     Salary = 2000
                 }
            );
            context.SaveChanges();
        }
    }
}