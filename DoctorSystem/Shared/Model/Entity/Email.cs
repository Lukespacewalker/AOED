﻿using System.ComponentModel.DataAnnotations;

namespace DoctorSystem.Shared.Model.Entity
{
    public class Email : Entity
    {
        [Required]
        public string Type { get; set; }
        [Required]
        [EmailAddress]
        public string Address { get; set; }
    }
}