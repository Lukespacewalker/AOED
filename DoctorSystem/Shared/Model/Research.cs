using System.ComponentModel.DataAnnotations;

namespace DoctorSystem.Shared.Model
{
    public enum ResearchType : byte
    {
        Thesis,
        ResearchPaper,
        Other
    }
    public class Research : Entity
    {
        [Required]
        public ResearchType ResearchType { get; set; }
        public string ThaiName { get; set; }
        public string EnglishName { get; set; }
        public string Journal { get; set; }
        [Url]
        public string Url { get; set; }
        [Url]
        public string DOI { get; set; }
    }
}