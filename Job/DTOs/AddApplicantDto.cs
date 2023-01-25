﻿using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace JobAPIS.DTOs
{
    public class AddApplicantDto
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [MaxLength(11), MinLength(11)]
        public string Phone { get; set; } = "12345678911";

        [Required]
        [Range(1, int.MaxValue)]
        public int JobId { get; set; }

    }
}
