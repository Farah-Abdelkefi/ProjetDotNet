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

        public DbSet<Admin> Admin { get; set; }
       public DbSet <Emprunt> Emprunt { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Emprunt>().HasKey(table => new {
                table.inscription_id,
                table.id_book
            });
        }
        private LibraryContext (DbContextOptions o) : base(o)
        { 
        
        }

        public static LibraryContext Instantiate_LibraryContext()
        {
            try
            {
                
                if (_context == null)
                {
                    
                    var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
                    optionsBuilder.UseSqlite(@"Data Source=C:\Users\ThinkPad\Documents\Projet\sqlite.db");
                    _context = new LibraryContext(optionsBuilder.Options);
                }

                return _context;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("une exception est trouvee" + ex.Message);
            }
            return _context;
        }
        

    }
}
