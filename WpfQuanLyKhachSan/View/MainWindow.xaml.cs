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
using WpfQuanLyKhachSan.View;
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

        public static Employee currentUser = null;

        private const string GuestHello = "Xin chào Tony Stark";


        public MainWindow()
        {
            InitializeComponent();

            EmployeeRepository employeeRepo = new EmployeeRepository();
            if (employeeRepo.FindAll().Count == 0) {
                FillEmployee();
            }

            Login_Click(null, null);
        }

        private void ChipUserSession_OnClick(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new View.Information(MyFrame, currentUser);
        }

        private void ChipUserSession_OnDeleteClick(object sender, RoutedEventArgs e)
        {
            currentUser = null;
            FlipStackPanelUserSession();
            chipUserSession.Content = GuestHello;
            MessageBox.Show("Đăng xuất thành công", "Đăng xuất", MessageBoxButton.OK, MessageBoxImage.Information);
            Login_Click(null, null);
        }

        private void FindAllRoom(object sender, RoutedEventArgs e)
        {
            /*List<TypeRoom> typeRooms = typeRoomViewModel.FindAll();
            Console.WriteLine("======>>>>>>>>sender: " + sender);
            foreach (TypeRoom item in typeRooms)
            {
                Console.WriteLine("======>>>>>>>>> type room name: " + $"{item.Price}");
            }*/


            /*foreach (Room item in rooms)
            {
                Console.WriteLine("======>>>>>>>>> type room name: " + $"{item.NameRoom}" + ": " + $"{item.TypeRoom.Price}");
            }*/

            if (currentUser != null)
            {
                MyFrame.Content = new View.Home(MyFrame);
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser != null)
            {
                MyFrame.Content = new View.Home(MyFrame);
            }            
        }

        private void ManagementHotel(object sender, RoutedEventArgs e)
        {
            if (currentUser != null)
            {
                if (currentUser.Role.Name == Role.ADMIN ||
                    currentUser.Role.Name == Role.MANAGER ||
                    currentUser.Role.Name == Role.TEST)
                { MyFrame.Content = new View.AdminManagement(); }
            }
        }

        private void RoomsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void Rental_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser != null)
            {
                MyFrame.Content = new View.Rental(MyFrame); 
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var loginFrame = new View.Login(MyFrame);
            MyFrame.Content = loginFrame;
            loginFrame.LoginHandler += user => {
                EmployeeRepository empRepo = new EmployeeRepository();
                currentUser = user;
                FlipStackPanelUserSession();
                chipUserSession.Content = "Xin chào " + currentUser.Fullname;
                HomeButton_Click(null, null);
            };
        }

        private void FlipStackPanelUserSession()
        {
            var children = stackPanelUserSession.Children;
            children[0].Visibility = Visibility.Visible;
            Stack<UIElement> stack = new Stack<UIElement>();
            for (int i = 0; i < children.Count; i++)
            {
                stack.Push(children[i]);
            }
            stack.Peek().Visibility = Visibility.Hidden;
            children.RemoveRange(0, children.Count);

            while (stack.Count > 0)
            {
                children.Add(stack.Pop());
            }
        }

        private void Transport_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser != null)
            {
                MyFrame.Content = new View.TotalDueBill(); 
            }
        }

        private void ReportBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser != null)
            {
                if (currentUser.Role.Name == Role.ADMIN ||
                    currentUser.Role.Name == Role.MANAGER ||
                    currentUser.Role.Name == Role.TEST)
                { MyFrame.Content = new View.Report(); }
            }
        }


        private void FillEmployee()
        {
            PasswordEncode passwordEncode = new PasswordEncode();
            var employees = new[]
            {
                new Employee{Fullname="Admin", Email="admin@gmail.com", Password=passwordEncode.EncodePasswordToBase64("123456"), RoleId=1},
                new Employee{Fullname="Manager", Email="manager@gmail.com", Password=passwordEncode.EncodePasswordToBase64("123456"), RoleId=2},

                new Employee{Fullname="employee1", Email="employee1@gmail.com", Password=passwordEncode.EncodePasswordToBase64("123456"), RoleId=3},
                new Employee{Fullname="employee2", Email="employee2@gmail.com", Password=passwordEncode.EncodePasswordToBase64("123456"), RoleId=3},

                new Employee{Fullname="employee3", Email="employee3@gmail.com", Password=passwordEncode.EncodePasswordToBase64("123456"), RoleId=3 },

                new Employee{Fullname="employee4", Email="employee4@gmail.com", Password=passwordEncode.EncodePasswordToBase64("123456"), RoleId=3}
            };

            EmployeeRepository employeeRepository = new EmployeeRepository();

            foreach(Employee employee in employees)
            {
                employeeRepository.Add(employee);
            }
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
