using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VovinamScoreManager.Models
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
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database = VOVINAM_SCORE_MNG ;uid=sa; pwd=sa;");
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

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.LimitScore).HasColumnName("LIMIT_SCORE");

                entity.Property(e => e.MaxScore).HasColumnName("MAX_SCORE");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("NAME");
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
