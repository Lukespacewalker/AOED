using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoctorSystem.Shared.Model
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
        byte[] RowVersion { get; set; }
        DateTimeOffset TimeStamp { get; set; }
    }

    public abstract class Entity : IEntity<int>
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }

    public class Doctor : Entity
    {
        [Required]
        public string ThaiName { get; set; }
        [Required]
        public string ThaiSurname { get; set; }
        [Required]
        public string EnglishName { get; set; }
        [Required]
        public string EnglishSurname { get; set; }
        [Required]
        public string Nickname { get; set; }
        [ValidateComplexType]
        public IList<Email> Emails { get; set; } = new List<Email>();
        public string LineId { get; set; }
        [ValidateComplexType]
        public IList<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
        [ValidateComplexType]
        public IList<Research> Researches { get; set; } = new List<Research>();
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

        public virtual ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }
    }
}
