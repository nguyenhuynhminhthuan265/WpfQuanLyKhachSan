using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfQuanLyKhachSan.Model
{
    class QuanLyKhachSanDbContext: DbContext
    {
        public QuanLyKhachSanDbContext() : base("QuanLyKhachSanConnectionString")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<TypeRoom> TypeRooms { get; set; }

    }
}
