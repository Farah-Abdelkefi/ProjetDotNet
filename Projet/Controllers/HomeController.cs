using Microsoft.AspNetCore.Mvc;
using Projet.Models;
using Projet.Data;
using System.Diagnostics;
using System.Xml.Linq;

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
            LibraryContext libraryContext = LibraryContext.Instantiate_LibraryContext();
            List<Book> books = libraryContext.Book.ToList();
            BookRepository bookRep = new BookRepository(libraryContext);
           
             List<Client> clients = libraryContext.Client.ToList();
          
            
            List<String> categories = (List<String>)bookRep.GetCategories();
            List<String> authors = (List<String>)bookRep.GetAuthors();
            List<int> available_min = (List<int>)bookRep.GetBooks();
            List<Book> popularBooks = new List<Book>();
            foreach(int id in available_min.Take(5))
            {
                popularBooks.Add((Book)bookRep.Get(id));
            }
            ViewBag.Message = false;
            ViewBag.popularBooks = popularBooks; 
            ViewBag.categories = categories;
            ViewBag.authors = authors.Take(5);

            return View(books);
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            ViewBag.Message = false;
            return View();
        }
        [HttpPost]
        public IActionResult LogIn( String email, String password )
        {
            LibraryContext libraryContext = LibraryContext.Instantiate_LibraryContext();
            ClientRepository studentRep = new ClientRepository (libraryContext);
            Debug.WriteLine(email, password);
            List<Client> clients = (List <Client>)studentRep.Find((s) => s.Email == email && s.Password == password);

            if (clients.Count == 0)
            {
                ViewBag.Message = true;
                return View();
            }
            else
            {
                Client c = (Client)clients[0];
                return Redirect(string.Format("/Client/Index/{0}", c.Inscription_Id));
            }
                
        }
        [HttpGet]
        public IActionResult SignUp()
        {

            ViewBag.Exist = false;
            ViewBag.message = false;
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(int id, String firstname, string lastname, String email, string phonenumber, String password)
        {
            LibraryContext libraryContext = LibraryContext.Instantiate_LibraryContext();
            ClientRepository studentRep = new ClientRepository(libraryContext);

            List<Client> clients = (List<Client>)studentRep.Find((s) => s.Inscription_Id==id);
            if (clients.Count == 0)
            {
                ViewBag.Exist = false;
                Client c = new Client(id, firstname, lastname, password, email, phonenumber);
                
                bool i = (bool)studentRep.Add(c);
               
                if (i == true) { return Redirect(string.Format("/Client/Index/{0}", id)); }
                else
                {
                    ViewBag.message = true;
                    return View();
                }
            }
            else {
                ViewBag.message = false;
                ViewBag.Exist = true;
                return View();       
            }
        }

        public IActionResult BookPage(int id)
        {
            LibraryContext libraryContext = LibraryContext.Instantiate_LibraryContext();
            BookRepository bookRep = new BookRepository(libraryContext);
            List<Book> bs = (List<Book>)bookRep.Find(v => v.Id_Book == id);
            Book b = bs.First();

            return View(b);
        }
        [HttpPost]
        public IActionResult FindBook(String Title)
        {
            LibraryContext libraryContext = LibraryContext.Instantiate_LibraryContext();
            BookRepository bookRep = new BookRepository(libraryContext);
            List<Book> bs = (List<Book>)bookRep.Find(v => v.Title.ToLower() == Title.ToLower());
            if(bs.Count()==0)
            {
                ViewBag.Message = true;
                return Redirect("/home/index");
            }
            else {
            Book b = (Book)bs.First();
            return Redirect(string.Format("/Home/BookPage/{0}", b.Id_Book));
            }
        }
        public IActionResult GetByCategory(String categorie)
        {
            
            LibraryContext Context = LibraryContext.Instantiate_LibraryContext();
             List<Book> books = Context.Book.ToList();
            List<Book> bs = new List<Book>();
            BookRepository bookRep = new BookRepository(Context);
            
            List<String> categories = (List<String>)bookRep.GetCategories();
            /* 
             List<Book> books = (List<Book>) bookRep.GetBooksByCategory(categorie);
             Debug.WriteLine("bon");*/
            Debug.WriteLine(books.Count(),categorie);
            foreach (Book book in books)
            {
                
                if (book.Category == categorie)
                {
                    Debug.WriteLine("cv : {0}  {1}", book.Category,book.Title);
                    bs.Add(book);
                }
            }
            Debug.WriteLine("cc4");
            ViewBag.Cat = categorie;
            ViewBag.categories = categories;
            return View(bs);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}