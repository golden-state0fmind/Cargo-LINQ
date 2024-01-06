using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cargolinq.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string DriverName { get; set; }
    }
}