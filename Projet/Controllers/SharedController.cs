using Microsoft.AspNetCore.Mvc;

namespace Projet.Controllers
{
    public class SharedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Navbar(bool exclude = false)
        {
            if (exclude)
            {
                return new EmptyResult();
            }

            return PartialView();
        }

    }
}
