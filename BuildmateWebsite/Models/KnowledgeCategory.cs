using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildmateWebsite.Models
{
    public class KnowledgeCategory
    {
        public int KnowledgeCategoryId { get; set; }
        public string Name { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public List<KnowledgeArticle> KnowledgeArticles { get; set; }
    }
}