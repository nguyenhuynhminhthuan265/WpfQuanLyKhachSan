using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfQuanLyKhachSan.Model;

namespace WpfQuanLyKhachSan.View
{
    public class RoomStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var roomStatus = (string)value;
            return (roomStatus.Equals(Room.EMPTY) ? Home.roomAvailable : Home.roomBooked);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
