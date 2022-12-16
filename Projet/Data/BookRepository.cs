using Projet.Models;
using Microsoft.EntityFrameworkCore;
namespace Projet.Data
{
    public interface IBookRepository:IRepository<Book>
    {
           
    }
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly LibraryContext _context;
        public BookRepository(LibraryContext db_context) : base(db_context)
        {
            this._context = db_context;
        }

        
    

        

    }
}
