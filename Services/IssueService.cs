using Prog7312_MunicipalityApp_ST10299399.Models;
using Prog7312_MunicipalityApp_ST10299399.Repositories;

namespace Prog7312_MunicipalityApp_ST10299399.Services
{
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;
        public IssueService(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }
        public void ReportNewIssue(Issue issue)
        {
            // Business logic can be added here before adding the issue
            issue.issueDate = DateTime.Now;
            issue.issueStatus = IssueStatus.Reported.ToString();

            _issueRepository.AddIssue(issue);
        }
        public Issue GetIssueDetails(int id)
        {
            return _issueRepository.GetIssueById(id);
        }
        public IEnumerable<Issue> GetAllIssues()
        {
            return _issueRepository.GetAllIssues();
        }
    }
}
