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
    /// Interaction logic for AdminRoom.xaml
    /// </summary>
    public partial class AdminManagement : Page
    {
        private RoomViewModel roomViewModel = new RoomViewModel();
        private void RoomsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }
        public AdminManagement()
        {
            InitializeComponent();
            List<Room> rooms = roomViewModel.findAll();
            RoomsGrid.ItemsSource = rooms;
        }
    }
}
