using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigifyAPI.Models
{
    public class CompanyRegistration
    {
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string NPWP { get; set; }

        [Required]
        public string DirectorName { get; set; }

        [Required]
        public string PICName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string? NPWPFilePath { get; set; }
        public string? PowerOfAttorneyFilePath { get; set; }

        public bool IsInvitationAccessAllowed { get; set; }

        [NotMapped]
        public IFormFile NPWPFile { get; set; }

        [NotMapped]
        public IFormFile PowerOfAttorneyFile { get; set; }
    }
}
