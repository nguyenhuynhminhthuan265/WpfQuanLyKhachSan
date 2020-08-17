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
            this.DataContext = currentUser;



        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
