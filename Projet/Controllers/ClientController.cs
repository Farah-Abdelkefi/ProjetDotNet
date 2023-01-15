using Microsoft.AspNetCore.Mvc;
using Projet.Data;
using Projet.Models;
using System.Diagnostics;

namespace Projet.Controllers
{
	public class ClientController : Controller
	{
        public IActionResult Index(int id)
        {
            LibraryContext libraryContext = LibraryContext.Instantiate_LibraryContext();
            ClientRepository clientRep = new ClientRepository(libraryContext);
            BookRepository bookRep = new BookRepository(libraryContext);
            List<Client> clients = (List<Client>)clientRep.Find(s => s.Inscription_Id == id);
            Client client = (Client)clients.FirstOrDefault();
            List<Book> books = libraryContext.Book.ToList();
            List<String> categories = (List<String>)bookRep.GetCategories();
            List<String> authors = (List<String>)bookRep.GetAuthors();
            List<int> available_min = (List<int>)bookRep.GetBooks();
            List<Book> popularBooks = new List<Book>();
            foreach (int i in available_min.Take(5))
            {
                popularBooks.Add((Book)bookRep.Get(i));
            }
            ViewBag.popularBooks = popularBooks;
            ViewBag.categories = categories;
            ViewBag.authors = authors.Take(5);

            ViewBag.client = client;
            return View(books);
        }

        public IActionResult MyBooks(int id)
		{
            LibraryContext libraryContext = LibraryContext.Instantiate_LibraryContext();
            EmpruntRepository empRep = new EmpruntRepository(libraryContext);
            BookRepository bookRep = new BookRepository(libraryContext);
            ClientRepository clientRep = new ClientRepository(libraryContext);
            List <Client> clients = (List<Client>) clientRep.Find(s=>s.Inscription_Id==id);
            Client client = (Client) clients.FirstOrDefault();
            Debug.WriteLine(client.Inscription_Id);
            List<Emprunt> emprunts = (List<Emprunt>) empRep.Find(s=>s.inscription_id==id );
            
            List<Book> books = new List<Book>();
            List<Book> books2;
            foreach (Emprunt emprunt in emprunts) {
                books2 = (List<Book>)bookRep.Find(s => s.Id_Book == emprunt.id_book);
                books.AddRange(books2);
            }
           
            ViewBag.client = client;
            ViewBag.emprunts = emprunts;
            return View(books);
		}
	}
}
