using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Prog7312_MunicipalityApp_ST10299399.ViewModels
{
    // ViewModel for reporting an issue
    public class ReportIssueViewModel
    {
        // Validation to ensure required fields are filled
        [Required(ErrorMessage = "Issue type is required.")]
        public string issueType { get; set; }

        // Validation to ensure description is provided and within length limits
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]

        // Property to hold the issue description
        public string issueDescription { get; set; }

        // Validation to ensure location is provided

        [Required(ErrorMessage = "Location is required.")]
        public string issueLocation { get; set; }

        // Image upload is optional
        public IFormFile? issueImage { get; set; }
    }
}
