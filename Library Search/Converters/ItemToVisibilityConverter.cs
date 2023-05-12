using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media.TextFormatting;
using Library_Search.Enums;

namespace Library_Search.Converters
{
    public class ItemToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (((SearchCriteriaEnum)value).Equals((SearchCriteriaEnum)parameter)) 
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
