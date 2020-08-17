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
    }
}
