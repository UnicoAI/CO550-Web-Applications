using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorApp.Data;
using RazorApp.Models;

namespace RazorApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly RazorApp.Data.ApplicationDbContext _context;

        public IndexModel(RazorApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ProductCategory { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = _context.Product
                .OrderBy(m => m.Category)
                .Select(m => m.Category)
                .Distinct();

            var products = _context.Product.AsQueryable();

            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ProductCategory))
            {
                products = products.Where(x => x.Category == ProductCategory);
            }

            Categories = new SelectList(await genreQuery.ToListAsync());
            Product = await products.ToListAsync();
        }
    }
}

