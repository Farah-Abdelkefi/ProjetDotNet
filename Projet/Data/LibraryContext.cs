using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Projet.Models;

namespace Projet.Data
{
    public class LibraryContext : DbContext
    {
        private static  LibraryContext _context = null;
        public DbSet<Book> Book { get; set; }
        public DbSet<Client>Client { get; set; }
        
        
       
   
        private LibraryContext(DbContextOptions o) : base(o)
        { 
        
        }

        public static LibraryContext Instantiate_LibraryContext()
        {
            try
            {
                
                if (_context == null)
                {
                    
                    var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
                    optionsBuilder.UseSqlite(@"Data Source=C:\Users\ThinkPad\Documents\web\c sharp\TP4\2022 GL3 .NET Framework TP4 - SQLite database.db");
                    _context = new LibraryContext(optionsBuilder.Options);
                }

                return _context;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("un exception est trouvee" + ex.Message);
            }
            return _context;
        }

    }
}
