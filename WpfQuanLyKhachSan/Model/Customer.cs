﻿using System;
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
        public int Id { get; set; }
        public string NameCustomer { get; set; }
        public string IDNumber { get; set; }
        public string Address { get; set; }
        public string TypeCustomer { get; set; }

        public DateTime dateRent { get; set; }
    }
}