using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfQuanLyKhachSan.Model
{
    class CardBookRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int RoomId { get; set; }

        

        public DateTime DateBookRoom { get; set; }

        public DateTime DateReturnRoom { get; set; }

        public float PriceBookRoom { get; set; }

        public ICollection<Customer> Customer { get; set; }


        public Boolean isDelete { get; set; }

        CardBookRoom()
        {
            isDelete = false;
        }

    }
}
