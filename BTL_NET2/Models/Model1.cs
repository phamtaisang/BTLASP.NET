namespace BTL_NET2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model_db")
        {
        }

        public virtual DbSet<account> account { get; set; }
        public virtual DbSet<bill> bill { get; set; }
        public virtual DbSet<billdetail> billdetail { get; set; }
        public virtual DbSet<category> category { get; set; }
        public virtual DbSet<feedback> feedback { get; set; }
        public virtual DbSet<producer> producer { get; set; }
        public virtual DbSet<PRODUCT> PRODUCT { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .HasMany(e => e.bill)
                .WithRequired(e => e.account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<account>()
                .HasMany(e => e.feedback)
                .WithRequired(e => e.account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<bill>()
                .HasMany(e => e.billdetail)
                .WithRequired(e => e.bill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<category>()
                .HasMany(e => e.PRODUCT)
                .WithOptional(e => e.category)
                .HasForeignKey(e => e.catID);

            modelBuilder.Entity<feedback>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.images)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .HasMany(e => e.billdetail)
                .WithRequired(e => e.PRODUCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCT>()
                .HasMany(e => e.feedback)
                .WithRequired(e => e.PRODUCT)
                .WillCascadeOnDelete(false);
        }
    }
}
