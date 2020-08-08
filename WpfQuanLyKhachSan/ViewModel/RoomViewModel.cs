using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.Model;
using WpfQuanLyKhachSan.Repository;

namespace WpfQuanLyKhachSan.ViewModel
{
    class RoomViewModel
    {
        private RoomRepository roomRepository = new RoomRepository();
        public List<Room> findAll()
        {
            List<Room> typeRooms = roomRepository.findAll();

            return typeRooms;
        }
    }
}
