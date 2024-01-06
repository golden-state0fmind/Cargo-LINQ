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

namespace cargolinq.Pages.Trucks
{
    public class IndexModel : PageModel
    {
        private readonly cargolinq.Data.TruckDbContext _context;

        public IndexModel(cargolinq.Data.TruckDbContext context)
        {
            _context = context;
        }
        public IList<Truck> Truck { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? TruckModels { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? TruckModel { get; set; }
        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> modelQuery = from m in _context.Truck
                                            orderby m.TruckModel
                                            select m.TruckModel;

            var trucks = from m in _context.Truck
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                trucks = trucks.Where(s => s.TruckModel.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(TruckModel))
            {
                trucks = trucks.Where(x => x.TruckModel == TruckModel);
            }
            TruckModels = new SelectList(await modelQuery.Distinct().ToListAsync());
            Truck = await trucks.ToListAsync();
        }
    }
}