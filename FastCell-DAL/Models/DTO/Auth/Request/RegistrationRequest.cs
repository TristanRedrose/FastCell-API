using FastCell_DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FastCell_DAL.Models.DTO.Auth.Request
{
    public class RegistrationRequest
    {
        [JsonPropertyName("email")]
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }

        [JsonPropertyName("passConfirm")]
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string PassConfirm { get; set; }

        [JsonPropertyName("name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [JsonPropertyName("phone")]
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [JsonPropertyName("country")]
        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [JsonPropertyName("city")]
        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [JsonPropertyName("adress")]
        [Required]
        [StringLength(50)]
        public string Adress { get; set; }

        [JsonPropertyName("postalCode")]
        [Required]
        [StringLength(50)]
        public string PostalCode { get; set; }

        [JsonPropertyName("position")]
        public string? Position { get; set; }

        [JsonPropertyName("active")]
        public bool? Active { get; set; }

        [JsonPropertyName("employmentType")]
        public EmploymentType? EmploymentType { get; set; }

        [JsonPropertyName("salary")]
        public int? Salary { get; set; }
    }
}
