using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.Model;

namespace WpfQuanLyKhachSan.Repository
{
    class CardBookRoomRepository
    {
        public List<CardBookRoom> FindAll()
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                return entities.CardBookRooms.Include("Customer").Include("Room").ToList();

            }
        }

        public void Add(CardBookRoom model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                entities.CardBookRooms.Add(model);
                entities.SaveChanges();
            }
        }
        public CardBookRoom FindById(int id)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.CardBookRooms.Include("Customer").Include("Room").FirstOrDefault(e => e.Id == id);
                if (item != null)
                {
                    return item;
                }

                return null;
            }
        }

        public void Update(CardBookRoom model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.CardBookRooms.FirstOrDefault(e => e.Id == model.Id);
                if (item != null)
                {
                    //item.Id = model.Id;
                    item.CustomerId = model.CustomerId;
                    item.DateBookRoom = model.DateBookRoom;
                    item.DateReturnRoom = model.DateReturnRoom;
                    item.CountCustomers = model.CountCustomers;
                    item.RoomId = model.RoomId;
                    item.isDelete = model.isDelete;
                    item.PriceBookRoom = model.PriceBookRoom;


                    entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                entities.SaveChanges();

            }
        }
    }
}
