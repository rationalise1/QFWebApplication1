using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreWrapper
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }
    }
    public partial class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public partial class UserRelationship
    {
        public int UserId { get; set; }
        public int RelatedId { get; set; }
    }

    public partial class UserPosition
    {
        public int UserId { get; set; }
        public int PositionId { get; set; }
    }

    public partial class UserLevel
    {
        public int UserId { get; set; }
        public int LevelId { get; set; }
    }
    public partial class Position
    {
        public int Id { get; set; }
        public string Name{ get; set; }
    }

    public partial class ModelContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserLevel> UserLevels { get; set; }
        public virtual DbSet<UserPosition> UserPositions { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<UserRelationship> UserRelationships { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=..\..\..\..\DB\DBLite\CompanyDB.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("sqlite_master_PK_UserId");

                entity.ToTable("Users");

                entity.Property(e => e.UserId).HasColumnName("UserId");

                entity.Property(e => e.UserName)
                    .HasColumnName("UserName")
                    .HasColumnType("varchar");

                entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .HasColumnType("varchar");

                entity.Property(e => e.Alias)
                    .HasColumnName("Alias")
                    .HasColumnType("varchar");

                entity.Property(e => e.FirstName)
                    .HasColumnName("FirstName")
                    .HasColumnType("varchar");

                entity.Property(e => e.LastName)
                    .HasColumnName("LastName")
                    .HasColumnType("varchar");

                entity.Property(e => e.Role)
                    .HasColumnName("Role")
                    .HasColumnType("varchar");

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("sqlite_master_PK_Role");

                entity.ToTable("Roles");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar");

            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("sqlite_master_PK_Positions");

                entity.ToTable("Positions");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar");
            });

            modelBuilder.Entity<UserLevel>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("sqlite_master_PK_UserLevels");

                entity.ToTable("UserLevels");

                entity.Property(e => e.UserId).HasColumnName("UserId");

                entity.Property(e => e.LevelId)
                    .HasColumnName("LevelId")
                    .HasColumnType("int");
            });

            modelBuilder.Entity<UserPosition>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("sqlite_master_PK_UserPositions");

                entity.ToTable("UserPositions");

                entity.Property(e => e.UserId).HasColumnName("UserId");

                entity.Property(e => e.PositionId)
                    .HasColumnName("PositionId")
                    .HasColumnType("int");
            });

            modelBuilder.Entity<UserRelationship>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("sqlite_master_PK_UserRelationships");

                entity.ToTable("UserRelationships");

                entity.Property(e => e.UserId).HasColumnName("UserId");

                entity.Property(e => e.RelatedId)
                    .HasColumnName("RelatedId")
                    .HasColumnType("int");
            });
        }
    }
}
