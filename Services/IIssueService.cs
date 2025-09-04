using Prog7312_MunicipalityApp_ST10299399.Models;

namespace Prog7312_MunicipalityApp_ST10299399.Services
{
    public interface IIssueService
    {
        void ReportNewIssue(Issue issue);
        Issue GetIssueDetails(int id);
        IEnumerable<Issue> GetAllIssues();

    }
}
