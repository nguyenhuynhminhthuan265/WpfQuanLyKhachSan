﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfQuanLyKhachSan.Model
{
    class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public float TotalPrice { get; set; }

        public int IdCardBookRoom { get; set; }


        [ForeignKey("IdEmployee")]
        public Employee Employee { get; set; }

        [ForeignKey("IdCardBookRoom")]
        public CardBookRoom CardBookRoom { get; set; }

        public Boolean isDelete = false;
    }
}