using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BashModels.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public string Rating { get; set; }
        public string Date { get; set; }
        public string PostName { get; set; }
        public string Text { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}