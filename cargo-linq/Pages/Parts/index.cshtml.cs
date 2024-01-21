using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cargolinq.Data;
using cargolinq.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace cargolinq.Pages.Parts
{
    public class IndexModel : PageModel
    {
        private readonly TruckDbContext _context;

        public IndexModel(TruckDbContext context)
        {
            _context = context;
        }
        public IList<TruckParts> TruckParts { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? TruckPartsModels { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? TruckPartsModel { get; set; }
        public async Task OnGetAsync()
        {
            // Using LINQ to query a list of truck parts.
            IQueryable<string> truckPartsQuery = from p in _context.TruckParts
                                                 orderby p.PartName
                                                 select p.PartName;

            var parts = from p in _context.TruckParts
                        select p;

            if (!string.IsNullOrEmpty(SearchString))
            {
                parts = parts.Where(p => p.PartName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(TruckPartsModel))
            {
                parts = parts.Where(p => p.PartName == TruckPartsModel);
            }

            TruckPartsModels = new SelectList(await truckPartsQuery.Distinct().ToListAsync());
            TruckParts = await parts.ToListAsync();
        }
    }
}

