using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet.Models
{
    [Table("Emprunt")]
  
    public class Emprunt
    {
        
        public int inscription_id { get; set; }
        
        public int id_book { get; set; }
        public String Deadline { get; set; }

    }
   
}
