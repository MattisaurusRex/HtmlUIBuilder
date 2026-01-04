using Microsoft.AspNetCore.Mvc;
using HtmlUI.Models;
using System.Diagnostics;

namespace HtmlUI.Controllers
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
            var model = new HomeModel();
            model.DashboardOptions = new Dictionary<string, string>
            {
                { "Files", "folder" },
                { "Customers", "customer" },
                { "Quotes", "quote" },
                { "Invoices", "invoice" }
            }; // these could easily be stored in DB

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Files()
        {
            var model = new HomeModel();
            model.DashboardOptions = new Dictionary<string, string>
            {
                { "Search", "magnifying-glass" },
                { "Create", "plus" },
            }; // these could easily be stored in DB
            
            return View(model);
        }

        public IActionResult Customers()
        {
            var model = new HomeModel();
            model.DashboardOptions = new Dictionary<string, string>
            {
                { "Search", "magnifying-glass" },
                { "Create", "plus" },
            }; // these could easily be stored in DB

            return View(model);
        }

        public IActionResult Quotes()
        {
            var model = new HomeModel();
            model.DashboardOptions = new Dictionary<string, string>
            {
                { "Search", "magnifying-glass" },
                { "Create", "plus" },
            }; // these could easily be stored in DB

            return View(model);
        }

        public IActionResult Invoices()
        {
            var model = new HomeModel();
            model.DashboardOptions = new Dictionary<string, string>
            {
                { "Search", "magnifying-glass" },
                { "Create", "plus" },
            }; // these could easily be stored in DB

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
