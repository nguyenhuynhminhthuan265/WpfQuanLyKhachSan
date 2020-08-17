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

namespace WpfQuanLyKhachSan.View
{
    /// <summary>
    /// Interaction logic for TotalDueBill.xaml
    /// </summary>
    public partial class TotalDueBill : Page
    {
        Frame myFrame;

        public TotalDueBill()
        {
            InitializeComponent();
        }

        public TotalDueBill(int idCardBookRoom,Frame frame)
        {
            InitializeComponent();
        }
    }
}
