using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class UserLogin
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
