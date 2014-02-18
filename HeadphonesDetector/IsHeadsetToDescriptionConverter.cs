using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HeadphonesDetector
{
    public class IsHeadsetToDescriptionConverter : IValueConverter
    {
        private const string DESCRIPTION_HEADPHONES = "Headphones attached. Put the record on!";
        private const string DESCRIPTION_SPEAKER = "Watch out, no headphones attached.";

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? DESCRIPTION_HEADPHONES : DESCRIPTION_SPEAKER;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((string)value).Equals(DESCRIPTION_HEADPHONES);
        }

    }
}
