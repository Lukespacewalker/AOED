using System.ComponentModel.DataAnnotations;

namespace DoctorSystem.Shared.Model.Authentication
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "ชื่อผู้ใช้")]
        [StringLength(100, ErrorMessage = "{0} ต้องมีตัวอักษรอย่างน้อย {2} และมากสุด {1}", MinimumLength = 4)]
        public string Username { get; set; }
        [Required]
        [Display(Name = "รหัสผ่าน")]
        [StringLength(100, ErrorMessage = "{0} ต้องมีตัวอักษรอย่างน้อย {2} และมากสุด {1}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
