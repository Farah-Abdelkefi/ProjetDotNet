using Projet.Models;
using Microsoft.EntityFrameworkCore;
namespace Projet.Data
{
    public interface IClientRepository : IRepository<Client>
    {

    }
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly LibraryContext _context;
        public ClientRepository(LibraryContext db_context) : base(db_context)
        {
            this._context = db_context;
        }


    }
}
