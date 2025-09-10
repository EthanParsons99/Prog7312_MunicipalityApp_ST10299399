using Prog7312_MunicipalityApp_ST10299399.Models;
using Prog7312_MunicipalityApp_ST10299399.Repositories;

namespace Prog7312_MunicipalityApp_ST10299399.Services
{
    // Service implementation for issue management
    public class IssueService : IIssueService
    {
        // Dependency injection for repository
        private readonly IIssueRepository _issueRepository;
        // Constructor to initialize repository
        public IssueService(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }
        // Reports a new issue
        public void ReportNewIssue(Issue issue)
        {
            // Business logic can be added here before adding the issue
            issue.issueDate = DateTime.Now;
            issue.issueStatus = IssueStatus.Reported.ToString();

            _issueRepository.AddIssue(issue);
        }
        // Retrieves issue details by ID
        public Issue GetIssueDetails(int id)
        {
            return _issueRepository.GetIssueById(id);
        }
        // Retrieves all issues
        public IEnumerable<Issue> GetAllIssues()
        {
            return _issueRepository.GetAllIssues();
        }
    }
}
