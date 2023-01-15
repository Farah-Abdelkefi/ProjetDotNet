using Projet.Models;
using Microsoft.EntityFrameworkCore;
namespace Projet.Data
{
    public interface IEmpruntRepository : IRepository<Emprunt>
    {

    }
    public class EmpruntRepository : Repository<Emprunt>, IEmpruntRepository    
    {
        private readonly LibraryContext _context;
        public EmpruntRepository(LibraryContext db_context) : base(db_context)
        {
            this._context = db_context;
        }
    }
}


   
   