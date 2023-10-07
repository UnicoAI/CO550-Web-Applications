using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorApp.Models;

namespace RazorApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RazorApp.Models.Product> Product { get; set; } = default!;
        public DbSet<RazorApp.Models.Category> Category { get; set; } = default!;
        public DbSet<RazorApp.Models.Product> Log2 { get; set; } = default!;
    
    }
}