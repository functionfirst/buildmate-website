using System;
using System.Linq;
using System.Data.Entity;

namespace BuildmateWebsite.Models
{
    public class BuildmateEntities : DbContext
    {
        public DbSet<KnowledgeCategory> KnowledgeCategories { get; set; }
        public DbSet<KnowledgeArticle> KnowledgeArticles { get; set; }
        public DbSet<Blog> BlogArticles { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
    }
}
