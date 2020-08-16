using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfQuanLyKhachSan.MainTest;
using WpfQuanLyKhachSan.Model;
using WpfQuanLyKhachSan.Repository;

namespace WpfQuanLyKhachSan.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        Frame Frame;
        public Login(Frame frame)
        {
            this.Frame = frame;
            InitializeComponent();
        }
        public Login() 
        { 
            InitializeComponent();
        }

        public delegate void SendResultDelegate(int userID);
        public event SendResultDelegate LoginHandler;

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = usernameTextBox.Text;
            string enteredPassword = passwordBox.Password;
            EmployeeRepository employeeRepository = new EmployeeRepository();
            List<Employee> allEmployees = employeeRepository.findAll();
            Employee findResult = allEmployees.Find(emp => emp.Email == enteredUsername);
            if (findResult != null)
            {
                PasswordEncode encoder = new PasswordEncode();
                if (findResult.Password.Equals(encoder.EncodePasswordToBase64(enteredPassword)))
                {
                    MessageBox.Show("Đăng nhập thành công!", "Đăng nhập", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoginHandler?.Invoke(findResult.Id);
                }
                else
                {
                    MessageBox.Show("Sai thông tin đăng nhập", "Lỗi đăng nhập", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Tên đăng nhập không tồn tại", "Lỗi đăng nhập...", MessageBoxButton.OK, MessageBoxImage.Error);
            }

           
            

        }
    }
}
