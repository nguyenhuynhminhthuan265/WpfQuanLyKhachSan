using MaterialDesignThemes.Wpf;
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
using WpfQuanLyKhachSan.Model;
using WpfQuanLyKhachSan.ViewModel;

namespace WpfQuanLyKhachSan.View
{
    /// <summary>
    /// Interaction logic for Information.xaml
    /// </summary>
    public partial class Information : Page
    {
        Frame MyFrame;
        Employee currentUser;
        /*public Information()
        {
            InitializeComponent();
        }

        public Information(Frame frame)
        {
            this.MyFrame = frame;
            InitializeComponent();
        }*/

        public Information(Frame frame, Employee currentUser)
        {
            this.MyFrame = frame;
            this.currentUser = currentUser;
           
            InitializeComponent();
            /*emailTextBox.Text = this.currentUser.Email;
            passwordBox.Text = this.currentUser.Password;
            idTextBox.Text = this.currentUser.Id.ToString();
            fullnameTextBox.Text = this.currentUser.Fullname;
            roleBox.Text = this.currentUser.Role.Description;*/
            this.DataContext = currentUser;
            //this.DataContext = currentUser;
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            List<Employee> employees = employeeViewModel.FindAll();
            string newEmail = emailTextBox.Text;

            Employee findResult = employees.Find(emp => emp.Id != currentUser.Id && emp.Email.Equals(newEmail));
            if (findResult != null)
            {
                MessageBox.Show("Tên đăng nhập/Email mới bị trùng. Hãy đổi sang Email khác.",
                    "Cập nhật thông tin", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                currentUser.Email = newEmail;
                currentUser.Fullname = fullnameTextBox.Text;
                employeeViewModel.Update(currentUser);

                MessageBox.Show("Cập nhật thông tin thành công!", "Cập nhật thông tin",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.MyFrame.Content = new View.Home(MyFrame);
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            PasswordChanging passwordChanging = new PasswordChanging(this.currentUser);
            passwordChanging.ShowDialog();
        }
    }
}
