using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Gisys.WebApi.Repository.Gisys
{
    public partial class GisysContext : DbContext
    {
        public GisysContext()
        {
        }

        public GisysContext(DbContextOptions<GisysContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Consultant> Consultants { get; set; }
        public virtual DbSet<NetResult> NetResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Consultant>(entity =>
            {
                entity.ToTable("Consultant");

                entity.Property(e => e.ConsultantId)
                    .ValueGeneratedNever()
                    .HasColumnName("consultantId");

                entity.Property(e => e.ChargedHours).HasColumnName("chargedHours");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.YearOfEmployment).HasColumnName("yearOfEmployment");
            });

            modelBuilder.Entity<NetResult>(entity =>
            {
                entity.ToTable("NetResult");

                entity.Property(e => e.NetResultId)
                    .ValueGeneratedNever()
                    .HasColumnName("netResultId");

                entity.Property(e => e.Net).HasColumnName("net");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
