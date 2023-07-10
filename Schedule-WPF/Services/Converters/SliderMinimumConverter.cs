using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Schedule_WPF.Services.Converters
{
    public class SliderMinimumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return -Math.Abs(System.Convert.ToInt32(value)*100);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
//return -Math.Abs(min * 12.2);
