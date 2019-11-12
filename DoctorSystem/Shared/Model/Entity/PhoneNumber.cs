using System.ComponentModel.DataAnnotations;

namespace DoctorSystem.Shared.Model.Entity
{
    public class PhoneNumber : Entity
    {
        [Required]
        public string Type { get; set; }
        [Required]
        [Phone]
        public string Number { get; set; }
    }
}