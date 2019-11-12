using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoctorSystem.Shared.Model.Authentication
{
    public class RegisterModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} ต้องมีตัวอักษรอย่างน้อย {2} และมากสุด {1}", MinimumLength = 4)]
        [Display(Name = "ชื่อผู้ใช้")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "อีเมลล์")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} ต้องมีตัวอักษรอย่างน้อย {2} และมากสุด {1}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "รหัสผ่าน")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ยืนยันรหัสผ่าน")]
        [Compare(nameof(Password), ErrorMessage = "รหัสผ่านไม่ตรงกัน")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "รหัสคำเชิญ")]
        [StringLength(32, ErrorMessage = "",MinimumLength = 0)]
        [NotMapped] public string InvitationKey { get; set; }
    }
}
