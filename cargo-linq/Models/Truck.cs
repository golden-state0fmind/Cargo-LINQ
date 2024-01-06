using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cargolinq.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public string DriverName { get; set; } = string.Empty;
        public string TruckModel { get; set; } = string.Empty;
        public string TruckMileage { get; set; } = string.Empty;
    }
}