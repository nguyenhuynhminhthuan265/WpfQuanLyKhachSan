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
using System.Windows.Shapes;
using WpfQuanLyKhachSan.MainTest;
using WpfQuanLyKhachSan.Model;
using WpfQuanLyKhachSan.ViewModel;

namespace WpfQuanLyKhachSan.View
{
    /// <summary>
    /// Interaction logic for PasswordChanging.xaml
    /// </summary>
    public partial class PasswordChanging : Window
    {
        Employee user;

        public PasswordChanging(Employee employee)
        {
            InitializeComponent();
            user = employee;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            string enteredOldPW = oldPasswordBox.Password;

            PasswordEncode passwordEncode = new PasswordEncode();

            if (user.Password.Equals(passwordEncode.EncodePasswordToBase64(enteredOldPW)))
            {
                string enteredNewPW = newPasswordBox.Password;
                string enteredRetype = retypePasswordBox.Password;

                if (enteredNewPW != "" && enteredNewPW.Equals(enteredRetype))
                {
                    string NewPassword = passwordEncode.EncodePasswordToBase64(enteredRetype);
                    user.Password = NewPassword;
                    EmployeeViewModel employeeViewModel = new EmployeeViewModel();
                    employeeViewModel.Update(user);

                    MessageBox.Show("Đổi mật khẩu thành công!", "Đổi mật khẩu", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nhập lại mật khẩu không khớp", "Đổi mật khẩu", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng!", "Sai mật khẩu", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

        }
    }
}
