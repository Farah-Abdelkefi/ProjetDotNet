using Projet.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Projet.Data
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetBooksByCategory(string categorie);
    }
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly LibraryContext _context;
        public BookRepository(LibraryContext db_context) : base(db_context)
        {
            this._context = db_context;
        }
        public IEnumerable<Book> GetBooksByCategory (string categorie)
        {
            return _context.Book.Where(s=>s.Category==categorie).ToList();
        }
        public IEnumerable<String> GetCategories()
        {
            return _context.Book.Select(s => s.Category).Distinct().ToList();
        }
        public IEnumerable<String> GetAuthors()
        {
            return _context.Book.Select(s => s.AuthorName).Distinct().ToList();
        }
        public IEnumerable<int> GetBooks()
        {
           return _context.Book.OrderBy(s => s.Available_Nbs).Select(s=>s.Id_Book).ToList();
            
        }



    }
}
