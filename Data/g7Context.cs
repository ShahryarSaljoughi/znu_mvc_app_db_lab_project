using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace myMVCApp
{
    public partial class g7Context : DbContext
    {
        public g7Context()
        {
        }

        public g7Context(DbContextOptions<g7Context> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Estate> Estate { get; set; }
        public virtual DbSet<EstateId> EstateId { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Maskooni> Maskooni { get; set; }
        public virtual DbSet<MoshakhasatMalek> MoshakhasatMalek { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestsFromZanjan> RequestsFromZanjan { get; set; }
        public virtual DbSet<RequestsSummary> RequestsSummary { get; set; }
        public virtual DbSet<Sortofland> Sortofland { get; set; }
        public virtual DbSet<Tejari> Tejari { get; set; }
        public virtual DbSet<Vekalat> Vekalat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=172.18.17.83;Database=g7;Username=g7;Password=g7;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cityname)
                    .IsRequired()
                    .HasColumnName("cityname")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Estate>(entity =>
            {
                entity.ToTable("estate");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.Arearequired).HasColumnName("arearequired");

                entity.Property(e => e.CityId).HasColumnName("cityId");

                entity.Property(e => e.Constructioarea).HasColumnName("constructioarea");

                entity.Property(e => e.Majorplaque)
                    .IsRequired()
                    .HasColumnName("majorplaque")
                    .HasColumnType("character varying");

                entity.Property(e => e.Minorplaque)
                    .IsRequired()
                    .HasColumnName("minorplaque")
                    .HasColumnType("character varying");

                entity.Property(e => e.Part)
                    .IsRequired()
                    .HasColumnName("part")
                    .HasColumnType("character varying");

                entity.Property(e => e.Projectname)
                    .IsRequired()
                    .HasColumnName("projectname")
                    .HasColumnType("character varying");

                entity.Property(e => e.SortOfLand).HasColumnName("sortOfLand");

                entity.Property(e => e.Totallandarea).HasColumnName("totallandarea");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Estate)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("cityFK");

                entity.HasOne(d => d.SortOfLandNavigation)
                    .WithMany(p => p.Estate)
                    .HasForeignKey(d => d.SortOfLand)
                    .HasConstraintName("sortOfLandFK");
            });

            modelBuilder.Entity<EstateId>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("estate_id");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("file");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Filetype).HasColumnName("filetype");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Maskooni>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("maskooni");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasColumnType("character varying");

                entity.Property(e => e.Majorplaque)
                    .HasColumnName("majorplaque")
                    .HasColumnType("character varying");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Projectname)
                    .HasColumnName("projectname")
                    .HasColumnType("character varying");

                entity.Property(e => e.ReqId).HasColumnName("req_id");
            });

            modelBuilder.Entity<MoshakhasatMalek>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("moshakhasat_malek");

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasColumnType("character varying");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mobileno)
                    .HasColumnName("mobileno")
                    .HasMaxLength(11);

                entity.Property(e => e.Nationalid)
                    .HasColumnName("nationalid")
                    .HasMaxLength(10);

                entity.Property(e => e.Telno)
                    .HasColumnName("telno")
                    .HasMaxLength(11);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasColumnType("character varying");

                entity.Property(e => e.Mobileno)
                    .IsRequired()
                    .HasColumnName("mobileno")
                    .HasMaxLength(11);

                entity.Property(e => e.Nationalid)
                    .IsRequired()
                    .HasColumnName("nationalid")
                    .HasMaxLength(10);

                entity.Property(e => e.Telno)
                    .IsRequired()
                    .HasColumnName("telno")
                    .HasMaxLength(11);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("request");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Estate).HasColumnName("estate");

                entity.Property(e => e.Malek).HasColumnName("malek");

                entity.Property(e => e.Mandata).HasColumnName("mandata");

                entity.Property(e => e.Vakil).HasColumnName("vakil");

                entity.HasOne(d => d.EstateNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.Estate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("request_fk");

                entity.HasOne(d => d.MalekNavigation)
                    .WithMany(p => p.RequestMalekNavigation)
                    .HasForeignKey(d => d.Malek)
                    .HasConstraintName("request_fk_1");

                entity.HasOne(d => d.MandataNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.Mandata)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("request_fk_3");

                entity.HasOne(d => d.VakilNavigation)
                    .WithMany(p => p.RequestVakilNavigation)
                    .HasForeignKey(d => d.Vakil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("request_fk_2");
            });

            modelBuilder.Entity<RequestsFromZanjan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("requests_from_zanjan");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Majorplaque)
                    .HasColumnName("majorplaque")
                    .HasColumnType("character varying");

                entity.Property(e => e.Minorplaque)
                    .HasColumnName("minorplaque")
                    .HasColumnType("character varying");

                entity.Property(e => e.Part)
                    .HasColumnName("part")
                    .HasColumnType("character varying");

                entity.Property(e => e.Projectname)
                    .HasColumnName("projectname")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<RequestsSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("requests_summary");

                entity.Property(e => e.MalekName)
                    .HasColumnName("malek_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.MalekNo)
                    .HasColumnName("malek_no")
                    .HasMaxLength(11);

                entity.Property(e => e.ReqId).HasColumnName("req_id");

                entity.Property(e => e.VakilName)
                    .HasColumnName("vakil_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Vakilno)
                    .HasColumnName("vakilno")
                    .HasMaxLength(11);
            });

            modelBuilder.Entity<Sortofland>(entity =>
            {
                entity.ToTable("sortofland");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Landsort)
                    .IsRequired()
                    .HasColumnName("landsort")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Tejari>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tejari");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasColumnType("character varying");

                entity.Property(e => e.Majorplaque)
                    .HasColumnName("majorplaque")
                    .HasColumnType("character varying");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Projectname)
                    .HasColumnName("projectname")
                    .HasColumnType("character varying");

                entity.Property(e => e.ReqId).HasColumnName("req_id");
            });

            modelBuilder.Entity<Vekalat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vekalat");

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasColumnType("character varying");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.ReqId).HasColumnName("req_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
