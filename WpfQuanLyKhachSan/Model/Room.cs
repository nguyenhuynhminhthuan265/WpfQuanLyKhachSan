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
    class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NameRoom { get; set; }

        public string Note { get; set; }


        public int TypeRoomId { get; set; }
        [ForeignKey("TypeRoomId")]
        public virtual TypeRoom TypeRoom { get; set; }

    }
}
