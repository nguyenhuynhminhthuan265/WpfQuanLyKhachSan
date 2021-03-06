﻿using System;
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
        public List<Room> FindAll()
        {
            List<Room> typeRooms = roomRepository.FindAll();

            return typeRooms;
        }


        public void Add(Room room)
        {
            roomRepository.Add(room);
        }

        public void UpdateIsDeleted(int id)
        {
            Room room = roomRepository.FindById(id);
            roomRepository.UpdateIsDeleted(room);
        }

        public void Update(Room room)
        {
            Console.WriteLine("id room in service update: " + room.Id);
            roomRepository.Update(room);
        }

        public Room FindById(int id)
        {
            return roomRepository.FindById(id);

        }

    }
}
