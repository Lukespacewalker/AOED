using System.Collections.Generic;

namespace DoctorSystem.Shared.Model.Authentication
{
    public class RegisterResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}