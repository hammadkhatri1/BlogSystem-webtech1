namespace webBlog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int commentId { get; set; }

        [StringLength(50)]
        public string userName { get; set; }

        public int? postId { get; set; }

        public string body { get; set; }

        public DateTime? timePosted { get; set; }
    }
}
