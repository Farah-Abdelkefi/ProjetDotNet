using System.ComponentModel.DataAnnotations.Schema;

namespace Projet.Models
{
    [Table ("book")]
    
    public class Book
    {
        public int Id_Book { get; set; }
        public string Title { get; set; }
        public int Pages_Nbs { get; set; }  
        public string ISBN { get; set; }
        public string AuthorName { get; set; }
        public int Copies_Nbs { get; set; }
        public int Available_Nbs { get; set; }
        public string Category { get; set; }

        
    }
}
