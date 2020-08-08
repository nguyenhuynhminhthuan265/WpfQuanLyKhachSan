using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.Model;

namespace WpfQuanLyKhachSan.Repository
{
    class TypeRoomRepository
    {
        public List<TypeRoom> findAll()
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                return entities.TypeRooms.ToList();

            }
        }

        public void Add(TypeRoom model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                entities.TypeRooms.Add(model);
                entities.SaveChanges();
            }
        }

        public void Delete(TypeRoom model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.TypeRooms.FirstOrDefault(e => e.Id == model.Id);
                entities.TypeRooms.Remove(item);
                entities.SaveChanges();
            }
        }


        public void Update(TypeRoom model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.TypeRooms.FirstOrDefault(e => e.Id == model.Id);
                if (item != null)
                {
                    item.Id = model.Id;
                    item.NameTypeRoom = model.NameTypeRoom;
                    item.Price = model.Price;


                    entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                entities.SaveChanges();

            }

        }
    }
}
