using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Account_Manager.Model
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string[] colorArray && colorArray.Length == 4)
            {
                byte a = byte.Parse(colorArray[0]);
                byte r = byte.Parse(colorArray[1]);
                byte g = byte.Parse(colorArray[2]);
                byte b = byte.Parse(colorArray[3]);

                return new SolidColorBrush(Color.FromArgb(a, r, g, b));
            }

            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
