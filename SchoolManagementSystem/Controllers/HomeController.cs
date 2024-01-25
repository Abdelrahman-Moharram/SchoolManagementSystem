using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
using System.Diagnostics;

namespace SchoolManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.Claims.FirstOrDefault(i => i.Type == "AdminId")?.Value != null)
            {
                return RedirectToAction(nameof(Index), nameof(Admin));
            }
            else if (User.Claims.FirstOrDefault(i => i.Type == "TeacherId")?.Value != null)
            {
                return RedirectToAction(nameof(Index), "ManageClassrooms");

            }
            else if (User.Claims.FirstOrDefault(i => i.Type == "StudentId")?.Value != null)
            {
                return RedirectToAction(nameof(Index), "Classroom");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("404")]
        public IActionResult PageNotFound()
        {
            string originalPath = "unknown";
            if (HttpContext.Items.ContainsKey("originalPath"))
            {
                originalPath = HttpContext.Items["originalPath"] as string;
            }
            return View();
        }
    }
}
