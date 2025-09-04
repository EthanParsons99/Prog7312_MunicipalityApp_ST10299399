using Prog7312_MunicipalityApp_ST10299399.Models;

namespace Prog7312_MunicipalityApp_ST10299399.Repositories
{
    public interface IIssueRepository
    {
        // Interface for issue repository
        // Defines methods for adding and retrieving issues
        void AddIssue(Issue issue);
        Issue GetIssueById(int id);
        IEnumerable<Issue> GetAllIssues();

    }
}
