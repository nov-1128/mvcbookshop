namespace bookshop
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;

    public partial class bookshopDB : DbContext
    {
        public bookshopDB()
            : base("name=bookshopDB")
        {
        }

        public virtual DbSet<book>  book { get; set; }
        public virtual DbSet<genre> genre { get; set; }
        public virtual DbSet<author> author { get; set; }
        public virtual DbSet<cart> cart { get; set; }
        public virtual DbSet<order> order{ get; set; }
        public virtual DbSet<orderdetail> orderdetail { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<book>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<genre>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<genre>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }

    }
}
