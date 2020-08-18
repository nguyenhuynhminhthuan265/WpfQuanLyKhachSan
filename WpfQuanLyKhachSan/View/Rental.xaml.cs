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

        CustomerViewModel customerViewModel = new CustomerViewModel();
        CardBookRoomViewModel cardBookRoomViewModel = new CardBookRoomViewModel();
        RoomViewModel roomViewModel = new RoomViewModel();
        BindingList<CardBookRoom> cardBookRooms;
        Frame myFrame;

        Room selectedRoom;

        public Rental(Frame frame)
        {

            InitializeComponent();

            //Console.WriteLine("==============>>>>>>>>>> ID ROOM BOOKED: " + $"{idRoom}");
            //txtBoxRoomName.Text = ;

            isSort = false;
            myFrame = frame;

            List<String> types = new List<String>();
            types.Add(Customer.DOMESTIC);
            types.Add(Customer.FOREIGNER);
            TypeComboBox.ItemsSource = types;

            cardBookRooms = new BindingList<CardBookRoom>(cardBookRoomViewModel.findAll());


            RentListView.ItemsSource = cardBookRooms;
        }

        public Rental(Room room, Frame frame)
        {
            InitializeComponent();
            this.myFrame = frame;
            this.idRoom = room.Id;
            this.selectedRoom = room;
            Console.WriteLine("==============>>>>>>>>>> ID ROOM BOOKED: " + $"{idRoom}");
            txtBoxRoomName.Text = room.NameRoom;
            PriceBookRoomTextBox.Text = room.TypeRoom.Price.ToString();

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
            //BindingList<CardBookRoom> listBookRooms = new BindingList<CardBookRoom>(cardBookRoomViewModel.findAll());
            //for(int i=0;i<listBookRooms.Count();i++)
            //{
            //    if(listBookRooms[i].RoomId != idRoom)
            //    {
            //        listBookRooms.RemoveAt(i);
            //    }
            //    else
            //    {
            //        listBookRooms[i].Room = roomViewModel.FindById(listBookRooms[i].RoomId);
            //        listBookRooms[i].Customer = customerViewModel.FindById(listBookRooms[i].CustomerId);
            //    }
            //}
            //cardBookRooms = listBookRooms;
            //RentListView.ItemsSource = cardBookRooms;

            BindingList<CardBookRoom> listBookRooms = new BindingList<CardBookRoom>(cardBookRoomViewModel.findAll());
            for (int i = listBookRooms.Count() - 1; i >= 0; i--)
            {
                if (listBookRooms[i].RoomId != idRoom)
                {
                    listBookRooms.RemoveAt(i);
                }
                else
                {
                    //listBookRooms[i].Room = roomViewModel.FindById(listBookRooms[i].RoomId);
                    //listBookRooms[i].Customer = customerViewModel.FindById(listBookRooms[i].CustomerId);
                }
            }

            RentListView.ItemsSource = listBookRooms;

            //cardBookRoom.Room = roomViewModel.FindById(idRoom);
            //MessageBox.Show($"Data {cardBookRoom.Room.NameRoom}");
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {


        }

        private void MouseDown_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var info = RentListView.SelectedItem as CardBookRoom;
            txtBoxRoomName.Text = info.Room.NameRoom;
            txtBoxCountCustomers.Text = info.CountCustomers.ToString();
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

            if (selectedRoom != null)
            {

                Console.WriteLine("==============>>>>>>>>>>>> Test ID ROOM BOOKING: " + selectedRoom.Id);
                if (txtBoxCountCustomers.Text.Trim().Length == 0)
                {
                    txtBoxCountCustomers.Text = "1";
                }
                int countCustomers = int.Parse(txtBoxCountCustomers.Text);
                Console.WriteLine("===============================>>>>>>>>>>>>>>>>>>>. So luong khach: " + countCustomers);
                /*INSERT Customer to database*/
                Customer customer = new Customer()
                {
                    NameCustomer = NameTextBox.Text,
                    IDNumber = CMNDTextBox.Text,
                    Address = AddressTextBox.Text,
                    TypeCustomer = TypeComboBox.SelectedValue.ToString(),
                    isDeleted = false
                };
/*                customerViewModel.Book(customer);
*/                

                CustomerRepository customerRepository = new CustomerRepository();
                /*customerRepository.Add(customer);*/
                //customers.Add(customer);

                Console.WriteLine("=========>>>>>>>>>>>>>.Test id Room update booked " + selectedRoom.Id);
                CardBookRoom cardBookRoom = new CardBookRoom()
                {
                    Customer = customer,
                    RoomId = selectedRoom.Id,
                    DateBookRoom = (DateTime)StartDatePicker.SelectedDate,
                    DateReturnRoom = (DateTime)EndDatePicker.SelectedDate,
                    CountCustomers = countCustomers,
                    PriceBookRoom = selectedRoom.TypeRoom.Price,
                    isDelete = false
                };



                selectedRoom.Status = Room.BOOKED;

                Console.WriteLine("=========>>>>>>>>>>>>>.Test id after Room update booked " + selectedRoom.Id);


                roomViewModel.Update(selectedRoom);

                CardBookRoomRepository cbrRepository = new CardBookRoomRepository();
                cbrRepository.Add(cardBookRoom);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn phòng nào để thuê!", "Thuê phòng...",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //Console.WriteLine("=================>>>>>>>>>>.. Start Date: " + $"{StartDatePicker.SelectedDate.Value}");
        //Console.WriteLine("=================>>>>>>>>>>.. End Date: " + $"{info.EndDate}");

        private void ConfirmUpdateBookRoom(object sender, RoutedEventArgs e)
        {
            //Room roomBook = roomViewModel.FindById(this.idRoom);
            //Console.WriteLine("================>>>>>>>>>>.. Price Room: " + roomBook.TypeRoom.Price);


            //string message = "Are you sure?";
            //string caption = "Confirmation";
            //if (customers.Count == 0)
            //{

            //    MessageBoxButton buttons = MessageBoxButton.YesNo;
            //    MessageBoxImage icon = MessageBoxImage.Question;
            //    MessageBox.Show(message, caption, buttons, icon);
            //}
            //else
            //{
            //    foreach(Customer customer in customers)
            //    {
            //        Console.WriteLine("=========>>>>>>>>>>>>>> name customer: " + customer.NameCustomer);
            //        customerViewModel.Book(customer);
            //    }

            //    /*GET LIST USER BOOKING*/
            //    List<Customer> customerBooks = customerViewModel.findAllCustomerBooking();
            //    /*info.StartDate = StartDatePicker.SelectedDate.Value;
            //    info.EndDate = StartDatePicker.SelectedDate.Value;*/
            //    foreach (Customer customer in customerBooks)
            //    {
            //        Console.WriteLine("=========>>>>>>>>>>>>>> ID customer is booking: " + customer.Id);
            //        CardBookRoom cardBookRoom = new CardBookRoom();
            //        cardBookRoom.RoomId = this.idRoom;

            //        cardBookRoom.CustomerId = customer.Id;
            //        cardBookRoom.DateBookRoom = StartDatePicker.SelectedDate.Value;
            //        cardBookRoom.DateReturnRoom = EndDatePicker.SelectedDate.Value;
            //        cardBookRoom.PriceBookRoom = cardBookRoom.GetPriceRoomRental(roomBook);
            //        cardBookRoom.CountCustomers = customerBooks.Count;
            //        cardBookRoomViewModel.Add(cardBookRoom);

            //        /*Update Customer attribute isBooking = "done"*/
            //        customerViewModel.UpdateBook(customer);


            //    }
            //}
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

                Console.WriteLine("============================>>>>>>>>>>>>>>>>>>>>>>>>> ID Phieu thue phong tinh hoa don: " + info.Id);

               myFrame.Content = new View.TotalDueBill(info, myFrame);
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
