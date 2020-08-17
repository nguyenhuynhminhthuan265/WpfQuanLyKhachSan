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
        Bill mainbill;
        public TotalDueBill()
        {
            InitializeComponent();
        }

        public TotalDueBill(int idCardBookRoom,Frame frame)
        {
            InitializeComponent();
            
            LoadPage(idCardBookRoom);
            this.DataContext = mainbill;

        }

        public void LoadPage(int idCardBookRoom)
        {
            BindingList<Bill> listBills = new BindingList<Bill>(billViewModel.findAll());
            double reportRevenue = 0;
            int reportTime = 0;

            //Lay lastbill khớp với idCardBookRoom
            for (int i = listBills.Count() - 1; i >= 0; i--)
            {
                if (listBills[i].IdCardBookRoom != idCardBookRoom)
                {
                    listBills.RemoveAt(i);
                }
                else
                {
                    mainbill = listBills[i];
                }
            }

            //Khoi tao gia tri Binding
            mainbill.CardBookRoom = cardBookRoomViewModel.FindById(mainbill.IdCardBookRoom);
            mainbill.Employee = employeeViewModel.FindById(mainbill.IdEmployee);
            mainbill.CardBookRoom.Room = roomViewModel.FindById(mainbill.CardBookRoom.RoomId);
            mainbill.CardBookRoom.Customer = customerViewModel.FindById(mainbill.CardBookRoom.CustomerId);
            mainbill.TotalPrice = mainbill.GetTotalPrice();
            reportRevenue += mainbill.TotalPrice;

            //Xu ly gia tri tinh toan
            double factor = (mainbill.CardBookRoom.Customer.TypeCustomer == Customer.FOREIGNER) ? 1.5 : 1.0;
            var timeSpan = mainbill.CardBookRoom.DateReturnRoom - mainbill.CardBookRoom.DateBookRoom;
            var surcharge = (mainbill.CardBookRoom.CountCustomers < mainbill.CardBookRoom.Room.TypeRoom.NumberOfCustomer) ? 0.25 : 0.0;
            reportTime += timeSpan.Days;

            //Gan gia tri vao nhung label tinh toan
            totalAmounLabel.Content = reportRevenue.ToString();
            timeSpanTxtBox.Text = reportTime.ToString();
            factorTxtBox.Text = factor.ToString();
            surchargeTxtBox.Text = surcharge.ToString();
        }
    }
}
