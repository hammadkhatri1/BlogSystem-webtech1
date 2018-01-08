namespace webBlog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        public DateTime? dateCreated { get; set; }

        [StringLength(50)]
        public string postedBy { get; set; }

        [StringLength(50)]
        public string category { get; set; }

        public string content { get; set; }

        [StringLength(50)]
        public string postName { get; set; }
    }
}
