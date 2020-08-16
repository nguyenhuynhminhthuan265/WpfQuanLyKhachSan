using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.Model;

namespace WpfQuanLyKhachSan.Repository
{
    class CustomerRepository
    {
        public List<Customer> findAll()
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                return entities.Customers.Where(c => c.isDeleted==false).ToList();

            }
        }

        public List<Customer> findAllCustomerBooking()
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                return entities.Customers.Where(c => c.isDeleted == false && c.isBooking.Equals("booking")).ToList();

            }
        }

        public void Add(Customer model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                entities.Customers.Add(model);
                entities.SaveChanges();
            }
        }
        public Customer FindById(int id)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.Customers.FirstOrDefault(e => e.Id == id);
                if (item != null)
                {
                    return item;
                }

                return null;
            }
        }
        public void Delete(Customer model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var Customer = entities.Customers.FirstOrDefault(e => e.Id == model.Id);
                entities.Customers.Remove(Customer);
                entities.SaveChanges();
            }
        }


        public void Update(Customer model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var Customer = entities.Customers.FirstOrDefault(e => e.Id == model.Id);
                if (Customer != null)
                {
                    Customer.Id = model.Id;
                    Customer.IDNumber = model.IDNumber;
                    Customer.NameCustomer = model.NameCustomer;
                    Customer.Address = model.Address;
                    Customer.TypeCustomer = model.TypeCustomer;
                    Customer.isBooking = model.isBooking;


                    entities.Entry(Customer).State = System.Data.Entity.EntityState.Modified;
                }
                entities.SaveChanges();

            }

        }


        public void UpdateIsDeleted(Customer model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.Customers.FirstOrDefault(e => e.Id == model.Id);
                if (item != null)
                {
                    item.isDeleted = true;


                    entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                entities.SaveChanges();

            }
        }
    }
}
