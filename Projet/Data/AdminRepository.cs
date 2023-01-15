using Projet.Models;

namespace Projet.Data
{

    public interface IAdminRepository : IRepository<Admin>
    {

    }
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        private readonly LibraryContext _context;
        public AdminRepository(LibraryContext db_context) : base(db_context)
        {
            this._context = db_context;
        }
    }


}