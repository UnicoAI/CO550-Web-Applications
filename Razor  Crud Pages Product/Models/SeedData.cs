using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorApp.Data;
using System;
using System.Linq;

namespace RazorApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
                    new Product
                    {
                        Title = "Basic",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Description = "Short Description",
                        Price = 400
                    },

                    new Product
                    {
                        Title = "Advanced ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Description = "Long Description",
                        Price = 600
                    }
                );
                context.SaveChanges();
            }
        }
    }
}