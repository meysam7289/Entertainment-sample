using Microsoft.EntityFrameworkCore;
using NosazEntertainment.Model;
using System.Threading.Tasks;

namespace NosazEntertainment.Data.Contexts
{
    public partial class nosazEntertainmentContext : DbContext, IUnitOfWork
    {
        public nosazEntertainmentContext()
        {
        }

        public nosazEntertainmentContext(DbContextOptions<nosazEntertainmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<SessionCategories> SessionCategories { get; set; }
        public virtual DbSet<SessionRounds> SessionRounds { get; set; }
        public virtual DbSet<SessionUsers> SessionUsers { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CancelReason).HasMaxLength(1000);

                entity.Property(e => e.CreationTime)
                    .HasColumnType("datetimeoffset(0)")
                    .HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.FkcancelUser).HasColumnName("FKCancelUser");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.FkcancelUserNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.FkcancelUser)
                    .HasConstraintName("FK_Session_User");
            });

            modelBuilder.Entity<SessionCategories>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkCategoryNavigation)
                    .WithMany(p => p.SessionCategories)
                    .HasForeignKey(d => d.FkCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SessionCategories_Category");

                entity.HasOne(d => d.FkSessionNavigation)
                    .WithMany(p => p.SessionCategories)
                    .HasForeignKey(d => d.FkSession)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SessionCategories_Session");
            });

            modelBuilder.Entity<SessionRounds>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationTime).HasColumnType("datetimeoffset(0)");

                entity.Property(e => e.RoundLetter)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.HasOne(d => d.FkSessionNavigation)
                    .WithMany(p => p.SessionRounds)
                    .HasForeignKey(d => d.FkSession)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SessionRounds_Session");
            });

            modelBuilder.Entity<SessionUsers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RefuseTime).HasColumnType("datetimeoffset(0)");

                entity.HasOne(d => d.FkSessionNavigation)
                    .WithMany(p => p.SessionUsers)
                    .HasForeignKey(d => d.FkSession)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SessionUsers_Session");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.SessionUsers)
                    .HasForeignKey(d => d.FkUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SessionUsers_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Family)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PersonnelCode).HasMaxLength(15);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNumber)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StatusMessage)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => new { e.FkUser, e.FkRole });

                entity.HasOne(d => d.FkRoleNavigation)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.FkRole)
                    .HasConstraintName("FK_UserRoles_Role");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.FkUser)
                    .HasConstraintName("FK_UserRoles_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public int SaveAllChanges()
        {
            return base.SaveChanges();
        }

        public async Task<int> SaveAllChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
