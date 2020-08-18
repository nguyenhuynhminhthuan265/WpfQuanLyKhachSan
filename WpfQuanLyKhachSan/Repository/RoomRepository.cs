using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                List<Room> rooms = entities.Rooms.Where(r => r.isDeleted == false).Include("TypeRoom").ToList();
                foreach (Room item in rooms)
                {
                    Console.WriteLine("======>>>>>>>>> type room name: " + $"{item.NameRoom}" + ": " + $"{item.TypeRoom.Price}");
                }
                return rooms;

            }
        }

        public void Add(Room model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                entities.Rooms.Add(model);
                entities.SaveChanges();
            }
        }

        public void Delete(Room model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.Rooms.FirstOrDefault(e => e.Id == model.Id);
                entities.Rooms.Remove(item);
                entities.SaveChanges();
            }
        }

        public Room FindById(int id)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.Rooms.Where(r => r.isDeleted == false).Include("TypeRoom").FirstOrDefault(e => e.Id == id);
                if (item != null)
                {
                    return item;
                }

                return null;
            }
        }
        public void Update(Room model)
        {
            Console.WriteLine("id room in service update: " + model.Id);
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.Rooms.FirstOrDefault(e => e.Id == model.Id);
                if (item != null)
                {
                    item.Id = model.Id;
                    item.NameRoom = model.NameRoom;
                    item.Note = model.Note;
                    item.TypeRoomId = model.TypeRoomId;
                    item.Status = model.Status;


                    entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                entities.SaveChanges();

            }

        }

        public void UpdateIsDeleted(Room model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.Rooms.FirstOrDefault(e => e.Id == model.Id);
                if (item != null)
                {
                    item.isDeleted=true;


                    entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                entities.SaveChanges();

            }
        }
    }
}
