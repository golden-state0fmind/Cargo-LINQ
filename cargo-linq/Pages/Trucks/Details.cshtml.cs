using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cargolinq.Data;
using cargolinq.Models;

namespace cargolinq.Pages.Trucks
{
    public class DetailsModel : PageModel
    {
        private readonly cargolinq.Data.TruckDbContext _context;

        public DetailsModel(cargolinq.Data.TruckDbContext context)
        {
            _context = context;
        }

        public Truck Truck { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Truck.FirstOrDefaultAsync(t => t.Id == id);
            if (truck == null)
            {
                return NotFound();
            }
            else
            {
                Truck = truck;
            }
            return Page();
        }
    }
}