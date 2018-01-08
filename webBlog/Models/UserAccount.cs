namespace webBlog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount
    {
        [StringLength(50)]
        public string firstName { get; set; }

        [StringLength(10)]
        public string lastName { get; set; }

        [Key]
        [StringLength(10)]
        public string userName { get; set; }

        [StringLength(10)]
        public string password { get; set; }
    }
}
