using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class User
    {

        public User() {
            UserType = "user";
        }

        [Key]
        public int Id { get; set; }

        public string? UserName{ get; set; }
       
        public string UserType { get; set; }

        public string? Email { get; set; }

        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];

    }
}
