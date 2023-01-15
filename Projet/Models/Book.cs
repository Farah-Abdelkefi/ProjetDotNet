using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet.Models
{
    [Table ("book")]
    
    public class Book
    {
        [Key]
        public int Id_Book { get; set; }
        public string Title { get; set; }
        public string Url{ get; set; }  
        public string ISBN { get; set; }
        public string Description { get; set; }

        public string AuthorName { get; set; }
        public int Copies_Nbs { get; set; }
        public int Available_Nbs { get; set; }
        public string Category { get; set; }

        
    }
}
