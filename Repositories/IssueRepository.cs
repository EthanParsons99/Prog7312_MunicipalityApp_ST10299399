using Prog7312_MunicipalityApp_ST10299399.Models;

namespace Prog7312_MunicipalityApp_ST10299399.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        // Static collection to hold issues in memory
        private static readonly IssueCollection _issues = new IssueCollection();

        // Adds a new issue to the collection
        public void AddIssue(Issue issue)
        {
            _issues.Add(issue);
        }

        // Retrieves an issue by its ID
        public Issue GetIssueById(int id)
        {
            return _issues.GetById(id);
        }

        // Retrieves all issues as an enumerable collection
        public IEnumerable<Issue> GetAllIssues()
        {
            return _issues;
        }
    }
}
