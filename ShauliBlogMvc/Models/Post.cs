using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShauliBlogMvc.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string SiteOfAuthor { get; set; }
        public DateTime PublishDate { get; set; }
        public string Content { get; set; }
        public byte[] Image { get; set;}
        public byte[] Video { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}