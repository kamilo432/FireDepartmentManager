using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FireDepartmentManager.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        [DisplayName("Type of vehicle")]
        public TypeOfVehicle TypeOfVehicle { get; set; }

        [Required]
        [DisplayName("Number of seats")]
        public int? NumberOfSeats { get; set; }

        public string? AutoPump { get; set; }
    }
    public enum TypeOfVehicle
    {
        Heavy,
        Medium,
        Light,
    }
}
