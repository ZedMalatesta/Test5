namespace Project5E.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SalesDBModel : DbContext
    {
        public SalesDBModel()
            : base("name=SalesModel")
        {
        }

        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<SaleInfo> SaleInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>()
                .Property(e => e.ManagerName)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .HasMany(e => e.SaleInfo)
                .WithRequired(e => e.Manager)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SaleInfo>()
                .Property(e => e.ClientName)
                .IsUnicode(false);

            modelBuilder.Entity<SaleInfo>()
                .Property(e => e.Product)
                .IsUnicode(false);
        }
    }
}
