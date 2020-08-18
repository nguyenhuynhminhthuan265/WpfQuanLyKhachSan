using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.Model;

namespace WpfQuanLyKhachSan.Repository
{
    class BillRepository
    {
        public List<Bill> findAll()
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                return entities.Bills.ToList();

            }
        }

        public Bill FindById(int id)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.Bills.FirstOrDefault(e => e.Id == id);
                return (item != null) ? item : null;
            }
        }

        public void Add(Bill model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                entities.Bills.Add(model);
                entities.SaveChanges();
            }
        }

        public void Delete(Bill model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.Bills.FirstOrDefault(e => e.Id == model.Id);
                entities.Bills.Remove(item);
                entities.SaveChanges();
            }
        }

        public void Update(Bill model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.Bills.FirstOrDefault(e => e.Id == model.Id);
                if (item != null)
                {


                    entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                entities.SaveChanges();

            }

        }
    }
}
