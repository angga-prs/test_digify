using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DigifyMVC.Models
{
    public class CompanyFormModel
    {
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

        [Required]
        public IFormFile NPWPFile { get; set; }

        [Required]
        public IFormFile PowerOfAttorneyFile { get; set; }

        public bool IsInvitationAccessAllowed { get; set; }
    }
}
