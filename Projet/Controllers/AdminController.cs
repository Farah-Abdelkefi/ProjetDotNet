using Microsoft.AspNetCore.Mvc;
using Projet.Models;
using Projet.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Projet.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            LibraryContext libraryContext = LibraryContext.Instantiate_LibraryContext();
            EmpruntRepository empruntRep = new EmpruntRepository(libraryContext);
            BookRepository bookRep = new BookRepository(libraryContext);

            List<Emprunt> emprunts = libraryContext.Emprunt.OrderBy(e => e.Deadline).ToList();



            ViewBag.books = bookRep;

            return View(emprunts);
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            ViewBag.message = false;
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(String login, String password)
        {
            LibraryContext libraryContext = LibraryContext.Instantiate_LibraryContext();
            AdminRepository adminRep = new AdminRepository(libraryContext);
            Debug.WriteLine(login, password);

            List<Admin> admins = (List<Admin>)adminRep.Find((s) => s.Login == login && s.Password == password);

            if (admins.Count == 0)
            {
                ViewBag.Message = true;
                return View();
            }
            else
            {
                return Redirect("Index");
            }


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}