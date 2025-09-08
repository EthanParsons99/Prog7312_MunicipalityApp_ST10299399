using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Prog7312_MunicipalityApp_ST10299399.ViewModels
{
    public class ReportIssueViewModel
    {
        [Required(ErrorMessage = "Issue type is required.")]
        public string issueType { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string issueDescription { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string issueLocation { get; set; }

        // Image upload is optional
        public IFormFile? issueImage { get; set; }
    }
}
