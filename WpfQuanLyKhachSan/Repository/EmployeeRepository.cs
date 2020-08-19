using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.Model;

namespace WpfQuanLyKhachSan.Repository
{
    class EmployeeRepository
    {
        public List<Employee> FindAll()
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                List<Employee> Employees = entities.Employees.Where(r => r.isDeleted == false).Include("Role").ToList();
                foreach (Employee item in Employees)
                {
                    Console.WriteLine("======>>>>>>>>> type Employee name: " + $"{item.Fullname}" + ": " + $"{item.Role.Name}");
                }
                return Employees;

            }
        }

        public void Add(Employee model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                entities.Employees.Add(model);
                entities.SaveChanges();
            }
        }

        public void Delete(Employee model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.Employees.FirstOrDefault(e => e.Id == model.Id);
                entities.Employees.Remove(item);
                entities.SaveChanges();
            }
        }

        public Employee FindById(int id)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.Employees.FirstOrDefault(e => e.Id == id);
                if (item != null)
                {
                    return item;
                }

                return null;
            }
        }
        public void Update(Employee model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.Employees.FirstOrDefault(e => e.Id == model.Id);
                if (item != null)
                {
                    item.Id = model.Id;
                    item.Fullname = model.Fullname;
                    item.Email = model.Email;
                    item.RoleId = model.RoleId;
                    item.Password = model.Password;


                    entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                entities.SaveChanges();

            }

        }

        public void UpdateNotPass(Employee model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.Employees.FirstOrDefault(e => e.Id == model.Id);
                if (item != null)
                {
                    item.Id = model.Id;
                    item.Fullname = model.Fullname;
                    item.Email = model.Email;
                    item.RoleId = model.RoleId;
                    


                    entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                entities.SaveChanges();

            }
        }

        public void UpdateIsDeleted(Employee model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.Employees.FirstOrDefault(e => e.Id == model.Id);
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
