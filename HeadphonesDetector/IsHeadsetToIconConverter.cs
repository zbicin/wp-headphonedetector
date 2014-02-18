using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HeadphonesDetector
{
    public class IsHeadsetToIconConverter : IValueConverter
    {
        private const string ICON_HEADPHONES = "\U0001f3a7";
        private const string ICON_SPEAKER = "\U0001f3ba";

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? ICON_HEADPHONES : ICON_SPEAKER;
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((string)value).Equals(ICON_HEADPHONES);
        }
    }
}
