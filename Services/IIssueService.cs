using Prog7312_MunicipalityApp_ST10299399.Models;

namespace Prog7312_MunicipalityApp_ST10299399.Services
{
    // Service interface for issue management
    public interface IIssueService
    {
        // Reports a new issue
        void ReportNewIssue(Issue issue);
        // Retrieves issue details by ID
        Issue GetIssueDetails(int id);
        // Retrieves all issues
        IEnumerable<Issue> GetAllIssues();

    }
}
