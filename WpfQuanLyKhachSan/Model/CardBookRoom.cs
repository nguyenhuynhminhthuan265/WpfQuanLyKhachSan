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

        public DateTime DateBookRoom { get; set; }

        public DateTime DateReturnRoom { get; set; }

        public double PriceBookRoom { get; set; }

        public int CountCustomers { get; set; }

        /*
         * public virtual ICollection<Customer> Customer { get; set; }
        */
        public int RoomId { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public double GetPriceRoomRental()
        {
            var timeSpan = DateReturnRoom - DateBookRoom;
            int days = timeSpan.Days;
            
            return days * Room.TypeRoom.Price;
        }

        public Boolean isDelete { get; set; }


    }
}
