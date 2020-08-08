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
using WpfQuanLyKhachSan.Repository;
using WpfQuanLyKhachSan.ViewModel;

namespace WpfQuanLyKhachSan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly QuanLyKhachSanDbContext context = new QuanLyKhachSanDbContext();

        private RoleRepository roleViewModel = new RoleRepository();

        private TypeRoomViewModel typeRoomViewModel = new TypeRoomViewModel();

        private RoomViewModel roomViewModel = new RoomViewModel();



        private void RoomsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        public MainWindow()
        {
          /*  roleViewModel.Add(new Role
            {
                Name= "Test",
                Description="test"
            });*/

            InitializeComponent();
            /*List<Role> roles = roleViewModel.findAll();

            foreach (Role role in roles)
            {
                Console.WriteLine("================> " + $"{role.Name}");
            }*/


        }

        private void ButtonsDemoChip_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicked Manage Employee Information");
        }

        private void ButtonsDemoChip_OnDeleteClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicked Logout");
        }

        private void FindAllRoom(object sender, RoutedEventArgs e)
        {
            /*List<TypeRoom> typeRooms = typeRoomViewModel.findAll();
            Console.WriteLine("======>>>>>>>>sender: " + sender);
            foreach (TypeRoom item in typeRooms)
            {
                Console.WriteLine("======>>>>>>>>> type room name: " + $"{item.Price}");
            }*/

            List<Room> rooms = roomViewModel.findAll();
            /*foreach (Room item in rooms)
            {
                Console.WriteLine("======>>>>>>>>> type room name: " + $"{item.NameRoom}" + ": " + $"{item.TypeRoom.Price}");
            }*/

            RoomsGrid.ItemsSource = rooms;

        }


        /*private void Fill()
        {
            var rooms = new[]
            {
                new Room {Number = "1", Type = RoomTypes.StandardRoom},
                new Room {Number = "2", Type = RoomTypes.JuniorSuite},
                new Room {Number = "3", Type = RoomTypes.StandardRoom},
                new Room {Number = "4", Type = RoomTypes.PresidentialSuite},
                new Room {Number = "5", Type = RoomTypes.JuniorSuite},
                new Room {Number = "6", Type = RoomTypes.StandardRoom},
                new Room {Number = "7", Type = RoomTypes.PresidentialSuite}
            };

            var clients = new[]
            {
                new Client {FirstName = "Stanislav", LastName = "Herasymiuk", Birthdate = new DateTime(1995, 9, 2), Account = "stas_the_best", Room = rooms[1]},
                new Client {FirstName = "Bob", LastName = "Marley", Birthdate = new DateTime(1952, 3, 25), Account = "919191", Room = rooms[3]},
                new Client {FirstName = "Frank", LastName = "Sinatra", Birthdate = new DateTime(1957, 7, 3), Account = "100500", Room = rooms[3]},
                new Client {FirstName = "Phill", LastName = "Colson", Birthdate = new DateTime(1966, 12, 6), Account = "S.H.I.E.L.D.", Room = rooms[5]},
                new Client {FirstName = "Dayzee", LastName = "Skay", Birthdate = new DateTime(1989, 10, 30), Account = "Hydra", Room = rooms[4]},
                new Client {FirstName = "Elvis", LastName = "Presley", Birthdate = new DateTime(1960, 2, 17), Account = "YA krevedko", Room = rooms[6]}
            };

            Context.Rooms.AddRange(rooms);
            Context.Clients.AddRange(clients);
            Context.SaveChanges();
        }*/
    }
}
