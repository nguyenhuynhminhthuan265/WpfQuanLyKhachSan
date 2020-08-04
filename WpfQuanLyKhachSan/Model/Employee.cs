using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfQuanLyKhachSan.Model
{
    class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int Id { get; set; }

        private string Fullname { get; set; }

        private string Email { get; set; }

        private string Password { get; set; }

        [ForeignKey("Role")]
        private int RoleId { get; set; }

        private Role Role { get; set; }


    }
}
