//using System;
//using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;

namespace BuildmateWebsite.Models
{
    public class FeedbackForm
    {
        [Required(ErrorMessage = "* Please enter a Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Please enter an Email")]
        public string Email { get; set; } 

        public string Phone { get; set; }
        
        [Required(ErrorMessage = "* Please enter a Message")]
        public string Message { get; set; }
    }
}