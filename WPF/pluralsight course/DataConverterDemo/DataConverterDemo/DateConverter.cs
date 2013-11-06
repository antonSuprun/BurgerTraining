using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;

namespace DataConverterDemo
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            return date.ToString("d");
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            String strValue = value as String;
            DateTime resultDateTime;
            
            if (!DateTime.TryParse(strValue, out resultDateTime))
            {
                throw new Exception("Unable to convert string to date time");    
            }
            
            return resultDateTime;
        }
    }
}
