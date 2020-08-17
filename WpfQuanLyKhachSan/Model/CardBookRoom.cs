using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfQuanLyKhachSan.Model
{
    public class CardBookRoom
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

        public int GetTimeSpan()
        {
            var timeSpan = this.DateReturnRoom - this.DateBookRoom;
            return timeSpan.Days;
        }

        public double GetFactor()
        {
            return (Customer.TypeCustomer == Customer.FOREIGNER) ? 1.5 : 1.0;
        }

        public double GetSurChargePercentage()
        {
            return (this.CountCustomers == this.Room.TypeRoom.NumberOfCustomer) ? 0.25 : 0.0;
        }

        public double GetPriceRoomRental()
        {
            double result;
            int days = GetTimeSpan();

            double factor = GetFactor();
            result = days * PriceBookRoom * factor;
            result = result + result * GetSurChargePercentage();
            
            return result;
        }
        public double GetPriceRoomRental(Room room)
        {
            this.Room = room;

            return GetPriceRoomRental();
        }


        public Boolean isDelete { get; set; }
        
    }
}
