using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfQuanLyKhachSan.Model
{
    class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int Id { get; set; }
        private string NameCustomer { get; set; }
        private string IDNumber { get; set; }
        private string Address { get; set; }
        private string TypeCustomer { get; set; }

        private DateTime dateRent { get; set; }
    }
}
