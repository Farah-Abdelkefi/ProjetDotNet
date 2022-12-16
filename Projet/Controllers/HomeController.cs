using Microsoft.AspNetCore.Mvc;
using Projet.Models;
using Projet.Data;
using System.Diagnostics;

namespace Projet.Controllers
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
            
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            ViewBag.notFound = false;
            return View();
        }
        [HttpPost]
        public IActionResult SignIn( String email, String password )
        {
            LibraryContext libraryContext = LibraryContext.Instantiate_LibraryContext();
            ClientRepository studentRep = new ClientRepository (libraryContext);
            Client client = (Client)studentRep.Find((s) => s.Email == email && s.Password == password);
            return View(client);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}