

using System;
using System.Globalization;
using System.Windows;

namespace SunnyLize.Word
{
    /// <summary>
    /// convert that take in a boolean if a message is sent by me align to the right
    /// if it is not sent by me align to the left
    /// </summary>
    public class SentByMeAlignmentConverter : BaseValueConverter<SentByMeAlignmentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null) //Default behaviour
                                   //if the value pass in is sent by me return horizentalAlignment to right : other to left
                return (bool)value ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            //Otherwise
            else
                return (bool)value ? HorizontalAlignment.Left : HorizontalAlignment.Right;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
