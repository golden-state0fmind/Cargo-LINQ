using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cargolinq.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        public string SupplierName { get; set; } = string.Empty;
        public string SupplierEmail { get; set; } = string.Empty;
        public string SupplierPhone { get; set; } = string.Empty;
        public virtual List<TruckParts> SuppliedParts { get; set; } = new List<TruckParts>();
    }
    public class TruckParts
    {
        [Key]
        public int TruckPartId { get; set; }

        public string PartNumber { get; set; } = string.Empty;
        public string PartName { get; set; } = string.Empty;
        public int PartQuantity { get; set; } = 0;
        public double PartPrice { get; set; } = 0.00;

        public int SupplierId { get; set; }
        public virtual Supplier? Supplier { get; set; }
    }
}