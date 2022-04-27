using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Bll_to_dbCinema
{
    public partial class dbCinemaContext : DbContext
    {
        public dbCinemaContext()
        {
        }

        public dbCinemaContext(DbContextOptions<dbCinemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Screening> Screenings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-JPC1MLUP\\SQLEXPRESS;Initial Catalog=dbCinema;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId)
                    .HasMaxLength(9)
                    .HasColumnName("ClientID");

                entity.Property(e => e.CreditCardNumber).HasMaxLength(20);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Phone).HasMaxLength(11);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.Director)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MovieLength).HasMaxLength(5);

                entity.Property(e => e.PosterPhoto).IsRequired();

                entity.Property(e => e.Summary).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasColumnName("ClientID");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.NumberOfTickets).HasColumnName("numberOfTickets");

                entity.Property(e => e.ScreeningId).HasColumnName("ScreeningID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Clients");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Movies");

                entity.HasOne(d => d.Screening)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ScreeningId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Screenings");
            });

            modelBuilder.Entity<Screening>(entity =>
            {
                entity.Property(e => e.ScreeningId).HasColumnName("ScreeningID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Day).HasMaxLength(10);

                entity.Property(e => e.Hour)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Screenings)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Screenings_Movies");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
