using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildmateWebsite.Models
{
    public class BlogCategory
    {
        public int BlogCategoryId { get; set; }
        public string Name { get; set; }
        public string Keywords { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}