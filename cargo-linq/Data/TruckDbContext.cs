using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cargolinq.Models;

namespace cargolinq.Data
{
    public class TruckDbContext : DbContext
    {
        public TruckDbContext(DbContextOptions<TruckDbContext> options) : base(options)
        {
        }
        public DbSet<Truck> Truck { get; set; } = default!;
        public DbSet<TruckParts> TruckParts { get; set; } = default!;
        public DbSet<Supplier> Suppliers { get; set; } = default!;
        public DbSet<TruckParts> SuppliedParts { get; set; } = default!;
    }
}