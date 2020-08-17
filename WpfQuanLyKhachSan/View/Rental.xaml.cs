using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfQuanLyKhachSan.View
{
    /// <summary>
    /// Interaction logic for Rental.xaml
    /// </summary>
    //class RentalInfo
    //{
       
    //    public string Name { get; set; }
    //    public string Type { get; set; }
    //    public int IDNumber { get; set; }
    //    public string Address { get; set; }
    //    public DateTime StartDate { get; set; }
    //    public DateTime EndDate { get; set; }
    //}
    public partial class Rental : Page
    {
        public bool isSort;
        //BindingList<CardBookRoom> rentalInfos = new BindingList<CardBookRoom>();

        private int idRoom { get; set; }
        ArrayList customers = new ArrayList();
        CustomerViewModel customerViewModel = new CustomerViewModel();
        CardBookRoomViewModel cardBookRoomViewModel = new CardBookRoomViewModel();
        RoomViewModel roomViewModel = new RoomViewModel();
        BindingList<CardBookRoom> cardBookRooms;
        Frame myFrame;
        public Rental()
        {
            
            InitializeComponent();
            this.idRoom = idRoom;
            Console.WriteLine("==============>>>>>>>>>> ID ROOM BOOKED: " + $"{idRoom}");
            txtBoxIdRoom.Text = this.idRoom.ToString();

            isSort = false;
            
            List<String> types = new List<String>();
            types.Add(Customer.DOMESTIC);
            types.Add(Customer.FOREIGNER);
            TypeComboBox.ItemsSource = types;
            //RentListView.ItemsSource = rentalInfos;

            cardBookRooms = new BindingList<CardBookRoom>(cardBookRoomViewModel.findAll());
            //RentListView.ItemsSource = cardBookRooms;            
        }

        public Rental(int idRoom, Frame frame)
        {
            InitializeComponent();
            this.myFrame = frame;
            this.idRoom = idRoom;
            Console.WriteLine("==============>>>>>>>>>> ID ROOM BOOKED: " + $"{idRoom}");
            txtBoxIdRoom.Text = this.idRoom.ToString();

            isSort = false;


            List<String> types = new List<String>();
            types.Add("Việt Nam");
            types.Add("Nước Ngoài");
            TypeComboBox.ItemsSource = types;
            //RentListView.ItemsSource = rentalInfos;
            LoadPage(idRoom);



        }

        public void LoadPage(int idRoom)
        {
            BindingList<CardBookRoom> listBookRooms = new BindingList<CardBookRoom>(cardBookRoomViewModel.findAll());
            for (int i = listBookRooms.Count() - 1; i >= 0; i--)
            {
                if (listBookRooms[i].RoomId != idRoom)
                {
                    listBookRooms.RemoveAt(i);
                }
                else
                {
                    listBookRooms[i].Room = roomViewModel.FindById(listBookRooms[i].RoomId);
                    listBookRooms[i].Customer = customerViewModel.FindById(listBookRooms[i].CustomerId);
                }
            }

            cardBookRooms = listBookRooms;
            RentListView.ItemsSource = cardBookRooms;

            //cardBookRoom.Room = roomViewModel.FindById(idRoom);
            //MessageBox.Show($"Data {cardBookRoom.Room.NameRoom}");
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void MouseDown_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var info = RentListView.SelectedItem as CardBookRoom;
            txtBoxAmount.Text = info.CountCustomers.ToString();
            PriceBookRoomTextBox.Text = info.PriceBookRoom.ToString();
            NameTextBox.Text = info.Customer.NameCustomer;
            TypeComboBox.SelectedValue = info.Customer.TypeCustomer.ToString();
            CMNDTextBox.Text = info.Customer.IDNumber.ToString();
            AddressTextBox.Text = info.Customer.Address;
            StartDatePicker.SelectedDate = info.DateBookRoom;
            EndDatePicker.SelectedDate = info.DateReturnRoom;
            
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //RentalInfo info = new RentalInfo();
            //info.Name = NameTextBox.Text;
            //info.Type = TypeComboBox.SelectedValue.ToString();
            //info.IDNumber = int.Parse(CMNDTextBox.Text);
            //info.Address = AddressTextBox.Text;
            //info.StartDate = StartDatePicker.SelectedDate.Value;
            //info.EndDate = EndDatePicker.SelectedDate.Value;

            /*INSERT Customer to database*/
            Customer customer = new Customer()
            {
                NameCustomer = NameTextBox.Text,
                IDNumber = CMNDTextBox.Text,
                Address = AddressTextBox.Text,
                TypeCustomer = TypeComboBox.SelectedValue.ToString(),
                isDeleted = false
            };
            
            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.Add(customer);
            //customers.Add(customer);


            CardBookRoom cardBookRoom = new CardBookRoom();
            cardBookRoom.RoomId = this.idRoom;
            cardBookRoom.isDelete = false;


            //Console.WriteLine("=================>>>>>>>>>>.. Start Date: " + $"{StartDatePicker.SelectedDate.Value}");
            //Console.WriteLine("=================>>>>>>>>>>.. End Date: " + $"{info.EndDate}");

        }

        private void ConfirmBookRoom(object sender, RoutedEventArgs e)
        {
            Room roomBook = roomViewModel.FindById(this.idRoom);
            Console.WriteLine("================>>>>>>>>>>.. Price Room: " + roomBook.TypeRoom.Price);

            string message = "Are you sure?";
            string caption = "Confirmation";
            if (customers.Count == 0)
            {

                MessageBoxButton buttons = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Question;
                MessageBox.Show(message, caption, buttons, icon);
            }
            else
            {
                foreach(Customer customer in customers)
                {
                    Console.WriteLine("=========>>>>>>>>>>>>>> name customer: " + customer.NameCustomer);
                    customerViewModel.Book(customer);
                }

                /*GET LIST USER BOOKING*/
                List<Customer> customerBooks = customerViewModel.findAllCustomerBooking();
                /*info.StartDate = StartDatePicker.SelectedDate.Value;
                info.EndDate = StartDatePicker.SelectedDate.Value;*/
                foreach (Customer customer in customerBooks)
                {
                    Console.WriteLine("=========>>>>>>>>>>>>>> ID customer is booking: " + customer.Id);
                    CardBookRoom cardBookRoom = new CardBookRoom();
                    cardBookRoom.RoomId = this.idRoom;
                    
                    cardBookRoom.CustomerId = customer.Id;
                    cardBookRoom.DateBookRoom = StartDatePicker.SelectedDate.Value;
                    cardBookRoom.DateReturnRoom = EndDatePicker.SelectedDate.Value;
                    cardBookRoom.PriceBookRoom = cardBookRoom.GetPriceRoomRental(roomBook);
                    cardBookRoom.CountCustomers = customerBooks.Count;
                    cardBookRoomViewModel.Add(cardBookRoom);

                    /*Update Customer attribute isBooking = "done"*/
                    customerViewModel.UpdateBook(customer);

                    
                }



            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            myFrame.Content = new View.Home(myFrame);
        }

        private void CheckOutButton_Click(object sender, RoutedEventArgs e)
        {
            if (RentListView.SelectedItem != null)
            {
                var info = RentListView.SelectedItem as CardBookRoom;
                myFrame.Content = new View.TotalDueBill(info.Id, myFrame);
            }
            else
            {
                MessageBox.Show("Ban chua chon Phieu Thue Phong!!!");
            }
        }

        /*public CardBookRoom createObject()
        {

        }*/
    }
}
