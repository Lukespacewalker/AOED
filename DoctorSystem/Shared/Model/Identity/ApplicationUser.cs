using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DoctorSystem.Shared.Model.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public virtual Entity.Doctor Doctor { get; set; }
    }
}