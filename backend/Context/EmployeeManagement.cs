using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    public class EmployeeManagement : DbContext, Icontext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  הגדרת קשר היררכי - מנהל ועובדים
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany(m => m.Subordinates)
                .HasForeignKey(e => e.ManagerId)
                .OnDelete(DeleteBehavior.Restrict); // מניעת מחיקת עובדים אם מוחקים מנהל

            //  קשר בין Employee ל- Role - עובד אחד יכול להיות משויך לתפקיד אחד בלבד
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Restrict); // מניעת מחיקה של עובדים אם מוחקים תפקיד

            //  הגדרת ערך ברירת מחדל לעמודת IsDeleted
            modelBuilder.Entity<Employee>()
                .Property(e => e.IsDeleted)
                .HasDefaultValue(false);
            //הגדרת השדה לייחודי
            modelBuilder.Entity<Employee>()
            .HasIndex(e => e.IdNumber)
            .IsUnique();
            //הגדרת השדה לייחודי
            modelBuilder.Entity<Role>()
            .HasIndex(r => r.Code)
           .IsUnique();

            // 🔹 הכנסת תפקידי ברירת מחדל בעת יצירת בסיס הנתונים
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Employee", Code = "5543", Created = new DateTime(2025, 1, 1), IsDeleted = false },
                new Role { Id = 2, Name = "Manager", Code = "664", Created = new DateTime(2025, 1, 1), IsDeleted = false },
                new Role { Id = 3, Name = "Senior Management", Code = "322", Created = new DateTime(2025, 1, 1), IsDeleted = false },
                new Role { Id = 4, Name = "OS Employee", Code = "876", Created = new DateTime(2025, 1, 1), IsDeleted = false }
            );

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localDb)\\msSqlLocalDb;database=EmployeeManagement;Trusted_Connection=True");
        }
    }

}
