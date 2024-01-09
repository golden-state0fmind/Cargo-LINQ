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
    public class DeleteModel : PageModel
    {
        private readonly cargolinq.Data.TruckDbContext _context;

        public DeleteModel(cargolinq.Data.TruckDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Truck.FindAsync(id);
            if (truck != null)
            {
                Truck = truck;
                _context.Truck.Remove(Truck);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./index");
        }
    }
}