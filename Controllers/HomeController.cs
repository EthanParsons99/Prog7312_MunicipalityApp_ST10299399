using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prog7312_MunicipalityApp_ST10299399.Models;
using Prog7312_MunicipalityApp_ST10299399.Services;
using Microsoft.AspNetCore.Hosting;
using Prog7312_MunicipalityApp_ST10299399.ViewModels;

namespace Prog7312_MunicipalityApp_ST10299399.Controllers
{
    // Handles main application logic
    public class HomeController : Controller
    {
        // Dependency injection for services
        private readonly IIssueService _issueService;
        // For handling file uploads
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IIssueService issueService, IWebHostEnvironment webHostEnvironment)
        {
            _issueService = issueService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReportIssue()
        {
            return View(new ReportIssueViewModel());
        }

        // Handles issue report submissions
        [HttpPost]
        public IActionResult ReportIssue(ReportIssueViewModel viewModel)
        {
            // Server-side validation
            if (ModelState.IsValid)
            {
                // Map ViewModel to Model
                var issue = new Issue
                {
                    issueType = viewModel.issueType,
                    issueDescription = viewModel.issueDescription,
                    issueLocation = viewModel.issueLocation,
                };

                // Set default values
                if (viewModel.issueImage != null && viewModel.issueImage.Length > 0)
                {
                    // Save image to wwwroot/uploads and store path
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.issueImage.FileName;
                     var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    Directory.CreateDirectory(uploads);

                    // Save the file
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        viewModel.issueImage.CopyTo(fileStream);
                    }
                    issue.issueImage = "/uploads/" + uniqueFileName;
                }
                _issueService.ReportNewIssue(issue);
                TempData["SuccessMessage"] = "Issue reported successfully!";

                return RedirectToAction("AllIssues");

            }
            return View(viewModel);
        }

        // Displays all reported issues
        public IActionResult AllIssues()
        {
            var allIssues = _issueService.GetAllIssues();
            return View(allIssues);
        }

    }
}
