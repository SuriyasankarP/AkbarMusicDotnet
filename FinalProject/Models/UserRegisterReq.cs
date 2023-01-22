using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models


{
    public class UserRegisterReq
    {
        
        public string? UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
  
        public string Password { get; set; } = string.Empty;
        
       

    }
}
