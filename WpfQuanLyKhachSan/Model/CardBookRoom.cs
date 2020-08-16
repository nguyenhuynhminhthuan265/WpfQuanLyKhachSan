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

       
        public int IndexCardBookRoom { get; set; }

        public DateTime DateBookRoom { get; set; }

        public DateTime DateReturnRoom { get; set; }

        public float PriceBookRoom { get; set; }

        /*        public virtual ICollection<Customer> Customer { get; set; }
        */
        public int RoomId { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }


        public ICollection<Bill> Bills;

        public Boolean isDelete { get; set; }


    }
}
