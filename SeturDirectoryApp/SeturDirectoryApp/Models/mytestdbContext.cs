using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SeturDirectoryApp.Models
{
    public partial class mytestdbContext : DbContext
    {
        public mytestdbContext()
        {
        }

        public mytestdbContext(DbContextOptions<mytestdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CantactInformation> CantactInformations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=mytestdb;\nTrusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CantactInformation>(entity =>
            {
                entity.HasKey(x => x.CantactInformationId);

                entity.ToTable("CantactInformation");

                entity.Property(e => e.Information).HasMaxLength(500);

                entity.Property(e => e.InformationType).HasMaxLength(500);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Uuid);

                entity.Property(e => e.Uuid).HasColumnName("UUID");

                entity.Property(e => e.Company).HasMaxLength(500);

                entity.Property(e => e.LastName).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
