using Microsoft.EntityFrameworkCore;
using cargolinq.Data;

namespace cargolinq.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TruckDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TruckDbContext>>()))
            {
                if (context == null || context.Truck == null)
                {
                    throw new ArgumentNullException("Null TruckDbContext");
                }

                // Look for any trucks.
                if (context.Truck.Any())
                {
                    return;   // DB has been seeded
                }

                context.Truck.AddRange(
                    new Truck
                    {
                        DriverName = "John Doe",
                        LicensePlate = "ABC123",
                        TruckModel = "Volvo VNL",
                        TruckMileage = "150,000 miles"
                    },

                    new Truck
                    {
                        DriverName = "Jane Smith",
                        LicensePlate = "XYZ789",
                        TruckModel = "Kenworth W900",
                        TruckMileage = "120,000 miles"
                    },

                    new Truck
                    {
                        DriverName = "Bob Johnson",
                        LicensePlate = "DEF456",
                        TruckModel = "Freightliner Cascadia",
                        TruckMileage = "180,000 miles"
                    },

                    new Truck
                    {
                        DriverName = "Alice Brown",
                        LicensePlate = "GHI789",
                        TruckModel = "Mack Anthem",
                        TruckMileage = "200,000 miles"
                    }
                );

                // Look for any suppliers.
                if (context.Suppliers.Any())
                {
                    return;   // DB has been seeded
                }

                var supplier = new Supplier
                {
                    SupplierName = "Supplier1",
                    SupplierEmail = "supplier1@example.com",
                    SupplierPhone = "123-456-7890"
                };

                context.Suppliers.Add(supplier);

                context.TruckParts.AddRange(
                    new TruckParts
                    {
                        PartNumber = "P001",
                        PartName = "Engine",
                        PartQuantity = 10,
                        PartPrice = 500.00,
                        Supplier = supplier
                    },

                    new TruckParts
                    {
                        PartNumber = "P002",
                        PartName = "Transmission",
                        PartQuantity = 8,
                        PartPrice = 300.00,
                        Supplier = supplier
                    }
                    // Add more TruckParts as needed...
                );
                context.SaveChanges();
            }
        }
    }
}