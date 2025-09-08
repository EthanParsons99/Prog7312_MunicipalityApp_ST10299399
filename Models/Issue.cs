using Microsoft.AspNetCore.Mvc;

namespace Prog7312_MunicipalityApp_ST10299399.Models
{
    // Blueprint for issue that gets submitted
    public class Issue
    {
        public int Id { get; set; }

        public string issueType { get; set; }

        public string issueDescription { get; set; }

        public string issueStatus { get; set; }

        public string issueLocation { get; set; }

        public string? issueImage { get; set; }

        public DateTime issueDate { get; set; }
    }

    // Makes code cleaner and prevents typos in status updates
    public enum IssueStatus
    {
        Reported,
        InProgress,
        Resolved,
        Closed,
    }
}
