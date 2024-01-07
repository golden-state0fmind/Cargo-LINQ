using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using cargolinq.Data;
using cargolinq.Models;

namespace cargolinq.Pages.Trucks
{
    public class CreateModel : PageModel
    {
        // Decalring a field only accessible to this class
        private readonly cargolinq.Data.TruckDbContext _context;

        // Adding method to this class that accepts a param and assigns _context a value
        public CreateModel(cargolinq.Data.TruckDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Truck Truck { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Truck.Add(Truck);
            await _context.SaveChangesAsync();

            return RedirectToPage("./index");
        }

    }
}