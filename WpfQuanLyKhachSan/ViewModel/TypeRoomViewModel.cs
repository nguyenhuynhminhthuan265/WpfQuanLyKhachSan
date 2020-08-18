using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.Model;
using WpfQuanLyKhachSan.Repository;

namespace WpfQuanLyKhachSan.ViewModel
{
    class TypeRoomViewModel
    {
        TypeRoomRepository typeRoomRepository = new TypeRoomRepository();

        public List<TypeRoom> FindAll()
        {
            List<TypeRoom> typeRooms = typeRoomRepository.FindAll();
            
            return typeRooms;
        }

        public List<TypeRoom> FindAllActive()
        {
            List<TypeRoom> typeRooms = typeRoomRepository.FindAllActive();

            return typeRooms;
        }
        public void Add(TypeRoom room)
        {
            typeRoomRepository.Add(room);
        }

        public void UpdateIsDeleted(int id)
        {
            TypeRoom room = typeRoomRepository.FindById(id);
            typeRoomRepository.UpdateIsDeleted(room);
        }

        public void Update(TypeRoom room)
        {
            typeRoomRepository.Update(room);
        }

        public TypeRoom FindById(int id)
        {
            return typeRoomRepository.FindById(id);

        }
    }
}
