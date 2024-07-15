

using System;
using System.Globalization;
using System.Windows;

namespace SunnyLize.Word
{
    /// <summary>
    /// convert that take in a boolean if a message is sent by me and return  the 
    /// the correct background color
    /// </summary>
    public class SentByMeToBackgroundConverter : BaseValueConverter<SentByMeToBackgroundConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //we check if the value of our current application is true
            //and message was truly sent by us return (WordVeryLightBlueBrush) if it is not we return Application.Current.FindResource("ForegroundLightBrush")
            return (bool)value ? Application.Current.FindResource("WordVeryLightBlueBrush") : Application.Current.FindResource("ForegroundLightBrush");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
