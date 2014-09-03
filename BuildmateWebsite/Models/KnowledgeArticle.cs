using System;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BuildmateWebsite.Models
{
    [Bind(Exclude = "KnowledgeArticleId")]
    public class KnowledgeArticle
    {
        [ScaffoldColumn(false)]
        public int KnowledgeArticleId { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "An Article Title is required")]
        [StringLength(120)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Keywords are required")]
        [StringLength(255)]
        public string Keywords { get; set; }

        [Required(ErrorMessage = "An Article Description is required")]
        [StringLength(1500)]
        public string Article { get; set; }

        public int ViewCount { get; set; }

        public string Attachment { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMMM d, yyyy}")]
        public DateTime DateModified { get; set; }

        public DateTime DateAdded { get; set; }

        public Boolean Hidden { get; set; }

        public virtual KnowledgeCategory KnowledgeCategory { get; set; }
    }
}