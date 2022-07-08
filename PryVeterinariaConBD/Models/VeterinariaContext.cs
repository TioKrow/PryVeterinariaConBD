using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PryVeterinariaConBD.Models
{
    public partial class VeterinariaContext : DbContext
    {
        public VeterinariaContext()
        {
        }

        public VeterinariaContext(DbContextOptions<VeterinariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PetFile> PetFiles { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESARROLLO\\SQLEXPRESS;Integrated Security=True;Database= Veterinaria;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<PetFile>(entity =>
            {
                entity.Property(e => e.BirthdayDate).HasColumnType("date");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.IdType).HasColumnName("Id_Type");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.PetFiles)
                    .HasForeignKey(d => d.IdType)
                    .HasConstraintName("FK_PetFiles_Types");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.Type1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
