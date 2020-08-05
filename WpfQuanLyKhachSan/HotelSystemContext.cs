/*namespace WpfQuanLyKhachSan
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using WpfQuanLyKhachSan.Model;

    public partial class HotelSystemContext : DbContext
    {
          public HotelSystemContext(): base("HotelSystem")
        {
            Database.SetInitializer<HotelSystemContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }


        public DbSet<Room> Rooms { get; set; }
        public DbSet<TypeRoom> TypeRooms { get; set; }
    }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
*/