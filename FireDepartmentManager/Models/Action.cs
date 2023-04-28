using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;

namespace FireDepartmentManager.Models
{
    public class Action
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public string? Commander { get; set; }
        public string? Driver { get; set; }
        public string? Rescuers { get; set; }
        public string? Vehicle { get; set; }

        [DisplayName("Type of action")]
        public TypeOfAction TypeOfAction { get; set; }

        [DisplayName("Date of alarm")]
        public DateTime DateOfAlarm { get; set; }

        [DisplayName("Date of action end")]
        public DateTime DateOfActionEnd { get; set; }

    }
    public enum TypeOfAction
    {
        Fire,
        [Display(Name = "Local danger")] LocalDanger,
        Fake
    }
}
