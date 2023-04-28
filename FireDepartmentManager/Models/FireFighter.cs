using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FireDepartmentManager.Models
{
    public class FireFighter
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        [DisplayName("First AID")]
        public bool FirstAID { get; set; } = false;

        public bool Commander { get; set; } = false;

        public bool Driver { get; set; } = false;

        [DisplayName("Date of course completion")]
        [DataType(DataType.Date)]
        public DateTime DateOfCourseCompletion { get; set; }
    }
}
