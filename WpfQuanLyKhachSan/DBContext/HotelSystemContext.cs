/*using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.Model;

namespace WpfQuanLyKhachSan
{
    class HotelSystemContext : DbContext
    {
        public HotelSystemContext(): base("HotelSystem")
        {

        }
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<Role> Roles { get; set; }


        public DbSet<Room> Roolms { get; set; }
        public DbSet<TypeRoom> TypeRooms { get; set; }
    }
}
*/