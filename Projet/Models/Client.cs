using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet.Models
{
    public class Client
    {
        [Key]
        public int Inscription_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }    
        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable <int> Id_Book { get; set; } 
        public Client() { }
        public Client (int Inscription_id,string FirstName,string LastName,string Password, string Email, string PhoneNumber)
        {
            this.Inscription_Id=Inscription_id;
            this.FirstName = FirstName;
            this.LastName = LastName;   
            this.Password = Password;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Id_Book = null;
               
        }
        
    }
}
