using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.Model;
using WpfQuanLyKhachSan.Repository;

namespace WpfQuanLyKhachSan.ViewModel
{
    class CustomerViewModel
    {
        private CustomerRepository customerRepository = new CustomerRepository();
        public List<Customer> FindAll()
        {
            List<Customer> customers = customerRepository.FindAll();

            return customers;
        }

        public List<Customer> FindAllCustomerBooking()
        {
            List<Customer> customers = customerRepository.FindAllCustomerBooking();

            return customers;
        }


        public void Add(Customer customer)
        {
            customer.isBooking = "done";
            customerRepository.Add(customer);
        }

        public void Book(Customer customer)
        {
            customer.isBooking = "booking";
            customerRepository.Add(customer);
        }

        public void UpdateBook(Customer customer)
        {
            customer.isBooking = "done";
            customerRepository.Update(customer);
        }

        public void UpdateIsDeleted(int id)
        {
            Customer customer = customerRepository.FindById(id);
            customerRepository.UpdateIsDeleted(customer);
        }

        public void Update(Customer customer)
        {
            customerRepository.Update(customer);
        }

        public Customer FindById(int id)
        {
            return customerRepository.FindById(id);

        }

        public Customer FindCustomerBooking()
        {
            return customerRepository.findCustomerBooking();

        }
    }
}
