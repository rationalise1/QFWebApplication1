using Microsoft.EntityFrameworkCore;
using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
        }

        public static string GetDBValues()
        {
            using (var db = new ModelContext())
            {
                // Creating a new department and saving it to the database
                //var newRole = new Role();
                //newRole.Id = 61;
                //newRole.Name = "Hey";
                //db.Role.Add(newRole);
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                // Retrieving and displaying data
                Console.WriteLine();
                Console.WriteLine("All departments in the database:");

                foreach (var role in db.Role)
                {
                    Console.WriteLine("{0} | {1}", role.Id, role.Name);
                    return role.Name;
                }

                return "Nothing found";
                //QFWebApiCore.Program.CreateWebHostBuilder(new string[] { });
            }
        }

        public partial class Role
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public partial class ModelContext : DbContext
        {
            public virtual DbSet<Role> Role { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite(@"DataSource=E:\Work\QuantifeedTest\DB\DBLite\CompanyDB.db;");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Role>(entity =>
                {
                    entity.HasKey(e => e.Id)
                        .HasName("sqlite_master_PK_Role");

                    entity.ToTable("Role", "DEMOBASE");

                    entity.Property(e => e.Id).HasColumnName("Id");

                    entity.Property(e => e.Name)
                        .HasColumnName("Name")
                        .HasColumnType("varchar");

                });

            }
        }
    }
}