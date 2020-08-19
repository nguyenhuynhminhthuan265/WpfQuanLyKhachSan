using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.Model;

namespace WpfQuanLyKhachSan.Repository
{
    class RoleRepository
    {
        public List<Role> FindAll()
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

        public Role FindById(int id)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.Roles.Where(r => r.isDeleted == false).FirstOrDefault(e => e.Id == id);
                if (item != null)
                {
                    return item;
                }

                return null;
            }
        }

        public Role FindRoleIdByName(string nameRole)
        {
            using (var entities = new QuanLyKhachSanDbContext())
            {
                var item = entities.Roles.Where(r => r.isDeleted == false).FirstOrDefault(e => e.Name.Equals(nameRole));
                if (item != null)
                {
                    return item;
                }

                return null;
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
