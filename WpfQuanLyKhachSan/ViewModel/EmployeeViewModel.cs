using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.Model;
using WpfQuanLyKhachSan.Repository;

namespace WpfQuanLyKhachSan.ViewModel
{
    class EmployeeViewModel
    {
        private EmployeeRepository employeeRepository = new EmployeeRepository();
        public List<Employee> findAll()
        {
            List<Employee> employees = employeeRepository.findAll();

            return employees;
        }


        public void Add(Employee employee)
        {
            employeeRepository.Add(employee);
        }

        public void UpdateIsDeleted(int id)
        {
            Employee employee= employeeRepository.FindById(id);
            employeeRepository.UpdateIsDeleted(employee);
        }

        public void Update(Employee employee)
        {
            employeeRepository.Update(employee);
        }
    }
}
