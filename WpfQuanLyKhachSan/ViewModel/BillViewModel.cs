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
        public List<Bill> findAll()
        {
            List<Bill> Bills = billRepository.findAll();

            return Bills;
        }
    }
}
