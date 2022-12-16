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
        public int Age  { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey("Book")]
        public int Id_Book { get; set; } 

        /*public Client (int Inscription_id,string FirstName,string LastName,string Password, int Age, string Email, string PhoneNumber, int Id_Book)
        {
            this.Inscription_Id=Inscription_id;
            this.FirstName = FirstName;
            this.LastName = LastName;   
            this.Password = Password;
            this.Age = Age;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.books.Add(book);
               
        }*/
        
    }
}
