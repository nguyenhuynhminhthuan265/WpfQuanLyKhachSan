using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using WpfQuanLyKhachSan.Converter;
using WpfQuanLyKhachSan.Model;
using WpfQuanLyKhachSan.ViewModel;

namespace WpfQuanLyKhachSan.View
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Page
    {
        CustomerViewModel customerViewModel = new CustomerViewModel();
        CardBookRoomViewModel cardBookRoomViewModel = new CardBookRoomViewModel();
        RoomViewModel roomViewModel = new RoomViewModel();
        BillViewModel billViewModel = new BillViewModel();
        EmployeeViewModel employeeViewModel = new EmployeeViewModel();
        BindingList<Bill> bills;

        public Report()
        {
            InitializeComponent();
            LoadPage();
        }

        private void LoadPage()
        {
            double reportRevenue = 0;
            int reportRoom = 0;
            double reportTime = 0;
            bills = new BindingList<Bill>(billViewModel.FindAll());
            foreach (var bill in bills)
            {
                bill.CardBookRoom = cardBookRoomViewModel.FindById(bill.IdCardBookRoom);
                bill.Employee = employeeViewModel.FindById(bill.IdEmployee);
                bill.CardBookRoom.Room = roomViewModel.FindById(bill.CardBookRoom.RoomId);
                bill.CardBookRoom.Customer = customerViewModel.FindById(bill.CardBookRoom.CustomerId);
                bill.TotalPrice = bill.GetTotalPrice();
                reportRevenue += bill.TotalPrice;
                reportRoom += 1;
                //var timeSpan = bill.CardBookRoom.GetTimeSpan();
                var timeSpan = bill.CardBookRoom.DateReturnRoom - bill.CardBookRoom.DateBookRoom;
                reportTime += timeSpan.TotalHours;
            }

            string money = reportRevenue.ToString();
            /*string.Format("{0:#.00}", Convert.ToDecimal(money) / 100);*/
            /*CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            string moneyFormatVN= double.Parse(money).ToString("#,###", cul.NumberFormat);*/

            RevenueLabel.Content = FormatCurrency.FormatCurrencyVN(money) + " đ";
            RoomRentLabel.Content = reportRoom.ToString();
            TimeRentLabel.Content = reportTime.ToString();
            ReportListview.ItemsSource = bills;
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
