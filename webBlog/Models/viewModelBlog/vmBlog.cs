using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webBlog.Models.viewModelBlog
{
    public class vmBlog
    {
        public IEnumerable<Post> posts{ get; set; }

        public IEnumerable<comment> comments{ get; set; }

        public Post post { get; set; }
        public UserAccount user{ get; set; }
    }
}