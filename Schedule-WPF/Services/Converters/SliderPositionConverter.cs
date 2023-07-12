using System;
using System.Globalization;
using System.Windows.Data;

namespace Schedule_WPF.Services.Converters
{
    public class SliderPositionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)values[0] - ((double)values[1]/2);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
