using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace Library_Search.Converters
{
    public class ItemToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Make the required checks here. if you content is comboboxitem or something you have to make the conversion here.
            //((System.Windows.Controls.ContentControl)value).Content.Equals(parameter.ToString())
            if (((System.Windows.Controls.ContentControl)value).Content.Equals(parameter.ToString()))
                return Visibility.Visible;

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
