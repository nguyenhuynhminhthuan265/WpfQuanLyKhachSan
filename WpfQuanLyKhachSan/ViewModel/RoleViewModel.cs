using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.Model;
using WpfQuanLyKhachSan.Repository;

namespace WpfQuanLyKhachSan.ViewModel
{
    class RoleViewModel
    {
        private RoleRepository roleRepository = new RoleRepository();
        public List<Role> FindAll()
        {
            return roleRepository.FindAll();
        }

        public void Add(Role model)
        {
            /* using (var entities = new QuanLyKhachSanDbContext())
             {
                 entities.Roles.Add(model);
                 entities.SaveChanges();
             }*/
            roleRepository.Add(model);
        }
        public Role FindById(int id)
        {
            /* using (var entities = new QuanLyKhachSanDbContext())
             {
                 entities.Roles.Add(model);
                 entities.SaveChanges();
             }*/
            return roleRepository.FindById(id);
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

        public Role FindRoleIdByName(string roleName)
        {
            return roleRepository.FindRoleIdByName(roleName);
        }


        public void Update(Role model)
        {
            /*using (var entities = new QuanLyKhachSanDbContext())
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

            }*/
            roleRepository.Update(model);

        }


    }
}
