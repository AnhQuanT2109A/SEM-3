using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcTest.Data;
using System;
using System.Linq;

namespace MvcTest.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcTestContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcTestContext>>()))
        {
            // Look for any Tests.
            if (context.Test.Any())
            {
                return;   // DB has been seeded
            }
            context.Test.AddRange(
                new Test
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Rating = "B",
                    Price = 7.99M
                },
                new Test
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Rating = "C",
                    Price = 8.99M
                },
                new Test
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Rating = "E",
                    Price = 9.99M
                },
                new Test
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Rating = "V",
                    Price = 3.99M
                },
                new Test
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-1-11"),
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M
                },
                new Test
                {
                    Title = "When Harry Met Sally2",
                    ReleaseDate = DateTime.Parse("1989-1-11"),
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M
                }
            );
            context.SaveChanges();
        }
    }
}