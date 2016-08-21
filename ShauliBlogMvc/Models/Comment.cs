using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShauliBlogMvc.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string SiteOfAuthor { get; set; }
        public string Content { get; set; }
        public Post Post { get; set; }
    }
}