using System;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BuildmateWebsite.Models
{
    public class Blog
    {
        [ScaffoldColumn(false)]
        public int BlogId { get; set; }

        public Guid UserId { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "An Article Title is required")]
        [StringLength(255)]
        public string Title { get; set; }

        [Required(ErrorMessage = "An Abstract is required")]
        [StringLength(255)]
        public string Abstract { get; set; }

        [Required(ErrorMessage = "Keywords are required")]
        [StringLength(255)]
        public string Keywords { get; set; }

        [Required(ErrorMessage = "An Article Description is required")]
        [StringLength(5000)]
        public string Article { get; set; }

        //[DisplayFormat(DataFormatString = "{0:d, yyyy}")]
        public DateTime DateCreated { get; set; }
        
        public Boolean Hidden { get; set; }

        public virtual BlogCategory BlogCategory { get; set; }
    }
}