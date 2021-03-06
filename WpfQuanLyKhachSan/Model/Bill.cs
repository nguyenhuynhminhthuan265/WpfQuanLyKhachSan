﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.ViewModel;

namespace WpfQuanLyKhachSan.Model
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double TotalPrice { get; set; }

        public int IdCardBookRoom { get; set; }

        public int IdEmployee { get; set; }
        [ForeignKey("IdEmployee")]
        public Employee Employee { get; set; }

        [ForeignKey("IdCardBookRoom")]
        public CardBookRoom CardBookRoom { get; set; }

        public Boolean isDeleted { get; set; }

        public double GetTotalPrice()
        {
            double total;
            total = this.CardBookRoom.GetPriceRoomRental();
            return total;
        }

    }
}
