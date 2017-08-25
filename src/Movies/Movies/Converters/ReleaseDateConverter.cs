using System;
using System.Globalization;
using Xamarin.Forms;

namespace Movies.Converters
{
    public class ReleaseDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime)
            {
                return ((DateTime)value).Year;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
