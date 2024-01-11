using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cargolinq.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string SupplierEmail { get; set; } = string.Empty;
        public string SupplierPhone { get; set; } = string.Empty;
        public ICollection<TruckParts> SuppliedParts { get; set; }
    }
    public class TruckParts
    {
        public int Id { get; set; }
        public string PartNumber { get; set; } = string.Empty;
        public string PartName { get; set; } = string.Empty;
        public int PartQuantity { get; set; } = 0;
        public double PartPrice { get; set; } = 0.00;
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}