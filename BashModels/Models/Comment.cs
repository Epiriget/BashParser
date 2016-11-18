using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BashModels.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int Text { get; set; }

        public virtual int PostID { get; set; }
        public virtual Post post { get; set; }
    }
}