using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfQuanLyKhachSan.Model
{
    class TypeRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string NameTypeRoom { get; set; }

        public float Price { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public Boolean isDeleted { get; set; }

        public TypeRoom()
        {
            isDeleted = false;
        }
    }
}
