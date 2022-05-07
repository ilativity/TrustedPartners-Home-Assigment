using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrustedPartnersHomeAssignment.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agents> Agents { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agents>(entity =>
            {
                entity.HasKey(e => e.AgentCode)
                    .HasName("PK__AGENTS__843A8BBAEFC9F5CB");

                entity.Property(e => e.AgentCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AgentName)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WorkingArea)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrdNum)
                    .HasName("PK__ORDERS__27AB607CA06F3B1F");

                entity.Property(e => e.OrdNum).ValueGeneratedNever();

                entity.Property(e => e.AgentCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CustCode).IsUnicode(false);

                entity.Property(e => e.OrdDescription).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
