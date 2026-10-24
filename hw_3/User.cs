using System.ComponentModel.DataAnnotations;

namespace hw_3
{
    public class User
    {
        public int UserId { get; set; }
        [EmailAddress]

        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
