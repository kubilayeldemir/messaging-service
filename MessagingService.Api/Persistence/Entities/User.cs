using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessagingService.Api.Persistence.Entities
{
    
    [Table("users")]
    public class User : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
        public bool CheckIfUserCredentialsCorrect(string username, string password)
        {
            return Username == username && Password == password;
        }
    }
}