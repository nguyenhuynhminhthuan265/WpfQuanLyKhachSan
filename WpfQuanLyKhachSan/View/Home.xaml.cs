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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private RoomViewModel roomViewModel = new RoomViewModel();
        Frame Frame;
        public Home()
        {
            InitializeComponent();
            List<Room> rooms = roomViewModel.findAll();
            roomComboBox.ItemsSource = rooms;
        }

        public Home(Frame frame)
        {
            this.Frame = frame;
            InitializeComponent();
            List<Room> rooms = roomViewModel.findAll();

            roomComboBox.ItemsSource = rooms;

            
        }

        private void roomComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BookRoom(object sender, RoutedEventArgs e)
        {
            var idRoom = ((Button)sender).Tag;
            Console.WriteLine("==============>>>>>>>>>> ID ROOM BOOKED: " + $"{idRoom}");
            Frame.Content = new View.Rental((int)idRoom);
        }
    }
}
