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
        public string Content { get; set; }
        public virtual Post Post { get; set; }
        public virtual Fan Author { get; set; }
        public virtual int AuthorID { get; set; }
    }
}