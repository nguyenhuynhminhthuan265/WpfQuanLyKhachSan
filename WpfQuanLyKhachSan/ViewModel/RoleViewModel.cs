using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.Model;

namespace WpfQuanLyKhachSan.ViewModel
{
    class RoleViewModel
    {
        public List<Role> findAll()
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                return entities.Roles.ToList();
               
            }
        }

        public void Add(Role model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                entities.Roles.Add(model);
                entities.SaveChanges();
            }
        }

        public void Delete(Role model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var role = entities.Roles.FirstOrDefault(e => e.Id == model.Id);
                entities.Roles.Remove(role);
                entities.SaveChanges();
            }
        }


        public void Update(Role model)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var role = entities.Roles.FirstOrDefault(e => e.Id == model.Id);
                if (role != null)
                {
                    role.Id = model.Id;
                    role.Name = model.Name;
                    role.Description = model.Description;
                   

                    entities.Entry(role).State = System.Data.Entity.EntityState.Modified;
                }
                entities.SaveChanges();

            }

        }
    }
}
