using System.ComponentModel.DataAnnotations;

namespace Projet.Models
{
    public class Admin
    {
        [Key]
        public int Id_Admin { get; set; } 
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
