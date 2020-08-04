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
        private int Id { get; set; }
        private string NameRoom { get; set; }
       
        private string Note { get; set; }

        [ForeignKey("TypeRoom")]
        private int TypeRoomId { get; set; }

        private TypeRoom TypeRoom { get; set; }

    }
}
