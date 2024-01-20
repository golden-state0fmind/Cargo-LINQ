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

        public IList<TruckParts> Part { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? TruckParts { get; set; }
    }
}
