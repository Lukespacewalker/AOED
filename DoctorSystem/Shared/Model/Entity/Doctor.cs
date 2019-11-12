using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DoctorSystem.Shared.Model.Identity;

namespace DoctorSystem.Shared.Model.Entity
{
    public abstract class DoctorBase : Entity
    {
        [Required]
        public string ThaiName { get; set; }
        [Required]
        public string ThaiSurname { get; set; }
        [Required]
        public string EnglishName { get; set; }
        [Required]
        public string EnglishSurname { get; set; }
        public string Nickname { get; set; }

        [Required]
        public int LicenseNumber { get; set; }
        [Required]
        public string ResidencyTraining { get; set; }
        [Required]
        public int ResidencyAdmissionBuddhistYear { get; set; }
        [Required]
        public string MedicalSchool { get; set; }
        [Required]
        public int Batch { get; set; }
        [Required]
        public string CurrentWorkplace { get; set; }
        [Required]
        public string CurrentPosition { get; set; }
        public string InterestedTopics { get; set; }
        public string LineId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }
    }

    public class DoctorBlazor : DoctorBase
    {
        [ValidateComplexType]
        public IList<Email> Emails { get; set; } = new List<Email>();
        [ValidateComplexType]
        public IList<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
        [ValidateComplexType]
        public IList<Research> Researches { get; set; } = new List<Research>();
    }

    public class Doctor : DoctorBase
    {
        public IList<Email> Emails { get; set; } = new List<Email>();
        public IList<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
        public IList<Research> Researches { get; set; } = new List<Research>();
    }
}
