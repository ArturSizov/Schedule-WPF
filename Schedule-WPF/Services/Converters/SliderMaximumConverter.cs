using System;
using System.Globalization;
using System.Windows.Data;

namespace Schedule_WPF.Services.Converters
{
    public class SliderMaximumConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return (System.Convert.ToInt32(values[0]) * 1500) - System.Convert.ToDouble(values[1]) + 15; // 25*5*12-win.ActualWidth;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
