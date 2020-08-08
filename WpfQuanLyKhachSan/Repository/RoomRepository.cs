using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.Model;

namespace WpfQuanLyKhachSan.Repository
{
    class RoomRepository
    {
        public List<Room> findAll()
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                List<Room> rooms = entities.Rooms.Include("TypeRoom").ToList();
                foreach (Room item in rooms)
                {
                    Console.WriteLine("======>>>>>>>>> type room name: " + $"{item.NameRoom}" + ": " + $"{item.TypeRoom.Price}");
                }
                return rooms;

            }
        }
    }
}
