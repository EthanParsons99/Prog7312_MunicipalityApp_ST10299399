using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prog7312_MunicipalityApp_ST10299399.Models;
using Prog7312_MunicipalityApp_ST10299399.Services;
using Microsoft.AspNetCore.Hosting;

namespace Prog7312_MunicipalityApp_ST10299399.Controllers
{
    // Handles main application logic
    public class HomeController : Controller
    {
        private readonly IIssueService _issueService;
        private readonly IWebHostEnvironment _webHostEnvironment;

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
        public IActionResult ReportIssue(Issue issue, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    Directory.CreateDirectory(uploadsFolder);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    issue.issueImage = "/uploads/" + uniqueFileName;
                }

                _issueService.ReportNewIssue(issue);

                TempData["SuccessMessage"] = "Issue reported successfully!";

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
