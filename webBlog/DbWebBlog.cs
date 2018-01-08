namespace webBlog
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbWebBlog : DbContext
    {
        public DbWebBlog()
            : base("name=DbWebBlog")
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>()
                .Property(e => e.lastName)
                .IsFixedLength();

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.userName)
                .IsFixedLength();

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.password)
                .IsFixedLength();
        }
    }
}
