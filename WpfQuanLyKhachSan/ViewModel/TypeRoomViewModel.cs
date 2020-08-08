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

        public List<TypeRoom> findAll()
        {
            List<TypeRoom> typeRooms = typeRoomRepository.findAll();
            
            return typeRooms;
        }

        public void Add(TypeRoom model)
        {
            
        }

        public void Delete(Role model)
        {
          
        }


        public void Update(Role model)
        {
           

        }
    }
}
