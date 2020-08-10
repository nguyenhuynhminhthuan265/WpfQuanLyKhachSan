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

namespace WpfQuanLyKhachSan.View
{
    /// <summary>
    /// Interaction logic for Rental.xaml
    /// </summary>
    class RentalInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int IDNumber { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public partial class Rental : Page
    {
        public bool isSort;
        BindingList<RentalInfo> rentalInfos = new BindingList<RentalInfo>();
        
        public Rental()
        {
            InitializeComponent();
            isSort = false;
            rentalInfos.Add(new RentalInfo() { Name = "Le Dinh Thanh", Type = "Nước Ngoài", IDNumber = 025868208, Address = "123 ABC",StartDate = new DateTime(2020,8,8),EndDate=new DateTime(2020,8,10) });
            rentalInfos.Add(new RentalInfo() { Name = "Nguyen Huynh Minh Thuan", Type = "Việt Nam", IDNumber = 01234567, Address = "123 ABC FDAJI WJREIQJFIQ DJAIFJIA", StartDate = new DateTime(2020, 8, 8), EndDate = new DateTime(2020, 8, 10) });
            rentalInfos.Add(new RentalInfo() { Name = "Nguyen Khanh Hoang", Type = "Việt Nam", IDNumber = 09876543, Address = "FDJAIJI MNKKNK JIFDAJIFDAJI ĐÀKÀKẠK FDJIAFJDIAFJDA", StartDate = new DateTime(2020, 8, 8), EndDate = new DateTime(2020, 8, 10) });
            List<String> types = new List<String>();
            types.Add("Việt Nam");
            types.Add("Nước Ngoài");
            TypeComboBox.ItemsSource = types;
            RentListView.ItemsSource = rentalInfos;
            
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void MouseDown_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var info = RentListView.SelectedItem as RentalInfo;
            NameTextBox.Text = info.Name;
            TypeComboBox.SelectedValue = info.Type.ToString();
            CMNDTextBox.Text = info.IDNumber.ToString();
            AddressTextBox.Text = info.Address;
            StartDatePicker.SelectedDate = info.StartDate;
            EndDatePicker.SelectedDate = info.EndDate;
            
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            RentalInfo info = new RentalInfo();
            info.Name = NameTextBox.Text;
            info.Type = TypeComboBox.SelectedValue.ToString();
            info.IDNumber = int.Parse(CMNDTextBox.Text);
            info.Address = AddressTextBox.Text;
            info.StartDate = StartDatePicker.SelectedDate.Value;
            info.EndDate = StartDatePicker.SelectedDate.Value;
            rentalInfos.Add(info);
        }
    }
}
