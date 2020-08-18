using System;
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
using WpfQuanLyKhachSan.ViewModel;

namespace WpfQuanLyKhachSan.View
{
    /// <summary>
    /// Interaction logic for TotalDueBill.xaml
    /// </summary>
    public partial class TotalDueBill : Page
    {
        Frame myFrame;
        CustomerViewModel customerViewModel = new CustomerViewModel();
        CardBookRoomViewModel cardBookRoomViewModel = new CardBookRoomViewModel();
        RoomViewModel roomViewModel = new RoomViewModel();
        BillViewModel billViewModel = new BillViewModel();
        EmployeeViewModel employeeViewModel = new EmployeeViewModel();
        Bill mainbill = new Bill();

        private string currencyUnit = " VND";

        public TotalDueBill()
        {
            InitializeComponent();

        }

        public TotalDueBill(CardBookRoom cardBookRoom, Frame frame)
        {
            InitializeComponent();
            myFrame = frame;

            LoadPage(cardBookRoom);
            this.DataContext = mainbill;

        }

        public void LoadPage(CardBookRoom cardBookRoom)
        {
            //BindingList<Bill> listBills = new BindingList<Bill>(billViewModel.findAll());
            //double reportRevenue = 0;
            //int reportTime = 0;

            int idCardBookRoom = cardBookRoom.Id;

            ////Lay lastbill khớp với idCardBookRoom
            //for (int i = listBills.Count() - 1; i >= 0; i--)
            //{
            //    if (listBills[i].IdCardBookRoom != idCardBookRoom)
            //    {
            //        listBills.RemoveAt(i);
            //    }
            //    else
            //    {
            //        mainbill = listBills[i];
            //        break;
            //    }
            //}

            //Khoi tao gia tri Binding
            

            mainbill.CardBookRoom = cardBookRoom;
            mainbill.Employee = MainWindow.currentUser;
            mainbill.CardBookRoom.Room = roomViewModel.FindById(cardBookRoom.RoomId);
            //mainbill.CardBookRoom.Customer = customerViewModel.FindById(mainbill.CardBookRoom.CustomerId);
            mainbill.isDeleted = false;
            mainbill.TotalPrice = mainbill.GetTotalPrice();
            

            ////Xu ly gia tri tinh toan
            //double factor = (mainbill.CardBookRoom.Customer.TypeCustomer == Customer.FOREIGNER) ? 1.5 : 1.0;
            //var timeSpan = mainbill.CardBookRoom.DateReturnRoom - mainbill.CardBookRoom.DateBookRoom;
            //var surcharge = (mainbill.CardBookRoom.CountCustomers < mainbill.CardBookRoom.Room.TypeRoom.NumberOfCustomer) ? 0.25 : 0.0;
            //reportTime += timeSpan.Days;

            //Gan gia tri vao nhung label tinh toan
            
            timeSpanTxtBox.Text = cardBookRoom.GetTimeSpan().ToString();
            factorTxtBox.Text = cardBookRoom.GetFactor().ToString();
            surchargeTxtBox.Text = (cardBookRoom.GetSurChargePercentage() * 100)
                .ToString();
            totalAmounLabel.Content = MyCurrencyFormatter(mainbill.TotalPrice) + currencyUnit;
        }

        private void BtnPayAndSaveBill_Click(object sender, RoutedEventArgs e)
        {
            /*billViewModel.Add(mainbill);
            Room roomEditStatus = roomViewModel.FindById(mainbill.CardBookRoom.RoomId);
            roomViewModel.Update(roomEditStatus);*/
            MessageBox.Show("Thanh toán thành công! Hóa đơn đã được lưu vào CSDL",
                "Thanh toán...", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private string MyCurrencyFormatter(double number)
        {
            string result = "";
            string temp = number.ToString();
            int i = temp.IndexOf(',');
            if (i >= 0)
            {
                result = temp.Substring(i);
            }
            else
            {
                i = temp.Length;
            }

            while (i - 3 >= 0)
            {
                result = " " + temp.Substring(i - 3, 3) + result;
                i -= 3;
            }
            result = result.Remove(0, 1);
            return result;
        }
    }
}
