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
        public int Id { get; set; }
        public string NameCustomer { get; set; }
        public string IDNumber { get; set; }
        public string Address { get; set; }
        public string TypeCustomer { get; set; }


        public ICollection<CardBookRoom> CardBookRoom { get; set; }
        /*public int RoomId { get; set; }

        public int CardBookRoomId { get; set; }*/

        /*[ForeignKey("RoomId")]
        public virtual Room Room { get; set; }*/

        /*[ForeignKey("CardBookRoomId")]
        public virtual CardBookRoom CardBookRoom { get; set; }*/


        public Boolean isDeleted { get; set; }

        public String isBooking { get; set; }
    }
}
