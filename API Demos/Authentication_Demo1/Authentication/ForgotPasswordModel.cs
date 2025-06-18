using System.ComponentModel.DataAnnotations;

namespace Authentication_Demo1.Authentication
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
