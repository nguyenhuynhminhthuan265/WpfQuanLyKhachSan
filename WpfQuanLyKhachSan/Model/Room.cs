using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfQuanLyKhachSan.Model
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NameRoom { get; set; }

        public string Note { get; set; }

        public const string EMPTY = "empty";
        public const string BOOKED = "booked";

        public int TypeRoomId { get; set; }
        [ForeignKey("TypeRoomId")]
        public virtual TypeRoom TypeRoom { get; set; }

        public string Status { get; set; }

        public virtual ICollection<CardBookRoom> CardBookRoom { get; set; }


        public Boolean isDeleted { get; set; }

        public static implicit operator Room(Employee v)
        {
            throw new NotImplementedException();
        }



    }
}
