using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfQuanLyKhachSan.Model
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public Boolean isDeleted { get; set; }

        public const string ADMIN = "ROLE_ADMIN";
        public const string MANAGER = "ROLE_MANAGER";
        public const string EMPLOYEE = "ROLE_EMPLOYEE";
        public const string TEST = "Test";


        public Role()
        {
            isDeleted = false;
        }
    }
}
