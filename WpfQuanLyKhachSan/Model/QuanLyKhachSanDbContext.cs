using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfQuanLyKhachSan.Model
{
    public class QuanLyKhachSanDbContext: DbContext
    {
        public QuanLyKhachSanDbContext() : base("QuanLyKhachSanConnectionString")
        {

        }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<CardBookRoom>().HasKey(sc => new { sc.CustomerId, sc.RoomId});*/


            /*modelBuilder.Entity<CardBookRoom>()
                        .HasOne<Customer>(sc => sc.Customer)
                        .WithMany(s => s.CardBookRoom)
                        .HasForeignKey(sc => sc.Id);


            modelBuilder.Entity<CardBookRoom>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.CId);*/

        }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().
              HasMany(c => c.Students).
              WithMany(p => p.CoursesAttending).
              Map(
               m =>
               {
                   m.MapLeftKey("CourseId");
                   m.MapRightKey("PersonId");
                   m.ToTable("PersonCourses");
               });
        }*/

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<TypeRoom> TypeRooms { get; set; }

        public DbSet<Revenue> Revenues { get; set; }

        public DbSet<CardBookRoom> CardBookRooms { get; set; }

        public DbSet<Bill> Bills { get; set; }
    }
}
