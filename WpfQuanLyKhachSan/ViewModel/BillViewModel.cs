using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.Model;
using WpfQuanLyKhachSan.Repository;

namespace WpfQuanLyKhachSan.ViewModel
{
    class BillViewModel
    {
        private BillRepository billRepository = new BillRepository();
        public List<Bill> FindAll()
        {
            List<Bill> Bills = billRepository.FindAll();

            return Bills;
        }

        public Bill FindById(int id)
        {
            return billRepository.FindById(id);

        }

        public void Add(Bill bill)
        {
            billRepository.Add(bill);
        }

        public void Update(Bill bill)
        {
            billRepository.Update(bill);
        }
    }
}
