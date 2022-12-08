using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcSM.Data;
using System;
using System.Linq;

namespace MvcSM.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcSMContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcSMContext>>()))
        {
            // Look for any movies.
            if (context.Structure.Any())
            {
                return;   // DB has been seeded
            }
            context.Structure.AddRange(
                new Structure
                {
                    Name = "Duong Duc Vinh",
                    ReleaseDate = DateTime.Parse("2003-2-12"),
                    Gender = "Male",
                    Student_Code = "TH2109034"
                },
                new Structure
                {
                    Name = "Kieu Minh Tuan",
                    ReleaseDate = DateTime.Parse("2003-4-11"),
                    Gender = "Male",
                    Student_Code = "TH2109024"
                },
                new Structure
                {
                    Name = "Tien Bip",
                    ReleaseDate = DateTime.Parse("2004-1-1"),
                    Gender = "Male",
                    Student_Code = "TH2109011"
                }
            );
            context.SaveChanges();
        }
    }
}