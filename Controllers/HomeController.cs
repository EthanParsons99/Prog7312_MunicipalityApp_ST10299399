using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prog7312_MunicipalityApp_ST10299399.Models;
using Prog7312_MunicipalityApp_ST10299399.Services;

namespace Prog7312_MunicipalityApp_ST10299399.Controllers
{
    // Handles main application logic
    public class HomeController : Controller
    {
        private readonly IIssueService _issueService;

        public HomeController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReportIssue()
        {
            return View(new Issue());
        }

        [HttpPost]
        public IActionResult ReportIssue(Issue issue)
        {
            if (ModelState.IsValid)
            {
                _issueService.ReportNewIssue(issue);
                return RedirectToAction("AllIssues");
            }
            return View(issue);
        }

        public IActionResult AllIssues()
        {
            var allIssues = _issueService.GetAllIssues();
            return View(allIssues);
        }
    }
}
