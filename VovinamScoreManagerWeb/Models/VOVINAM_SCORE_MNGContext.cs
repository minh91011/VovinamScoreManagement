using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace VovinamScoreManagerWeb.Models
{
    public partial class VOVINAM_SCORE_MNGContext : DbContext
    {
        public VOVINAM_SCORE_MNGContext()
        {
        }

        public VOVINAM_SCORE_MNGContext(DbContextOptions<VOVINAM_SCORE_MNGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conf = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conf.GetConnectionString("DBConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("ACCOUNT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccRule).HasColumnName("ACC_RULE");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .HasColumnName("FULL_NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("CLASS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("CODE");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("NAME");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__CLASS__ACCOUNT_I__29572725");
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.ToTable("RANK");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LimitScore).HasColumnName("LIMIT_SCORE");

                entity.Property(e => e.MaxScore).HasColumnName("MAX_SCORE");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("NAME");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("IMAGE");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.ToTable("SCORE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Score1).HasColumnName("SCORE");

                entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__SCORE__STUDENT_I__34C8D9D1");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.ClassId).HasColumnName("CLASS_ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("CODE");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .HasColumnName("FULL_NAME");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("PHONE");

                entity.Property(e => e.RankId).HasColumnName("RANK_ID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__STUDENT__CLASS_I__2F10007B");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("FK__STUDENT__RANK_ID__31EC6D26");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
