using System.ComponentModel.DataAnnotations;

namespace BuildmateWebsite.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage = "* Please enter a Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Please enter an Email")]
        public string Email { get; set; } 
        
        [Required(ErrorMessage = "* Please enter a Message")]
        public string Message { get; set; }
    }
}