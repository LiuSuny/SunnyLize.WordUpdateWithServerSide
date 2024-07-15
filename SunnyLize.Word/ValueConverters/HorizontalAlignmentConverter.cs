

using SunnyLize.Word.Core;
using System;
using System.Globalization;
using System.Windows;

namespace SunnyLize.Word
{
    /// <summary>
    /// A converter that takes in the core Horizental alignment enum and convert it to WPF alignment 
    /// </summary>
    public class HorizontalAlignmentConverter : BaseValueConverter<HorizontalAlignmentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            #region Playing Around
            ////THis is only in process if our enum element changes 
            //var realValue = (ElementHorizontalAlignment)value;
            //switch (realValue)
            //{
            //    case ElementHorizontalAlignment.Left:
            //        return HorizontalAlignment.Left;

            //    case ElementHorizontalAlignment.Right:
            //        return HorizontalAlignment.Right;
            //} 
            #endregion

            //However since our enum is solid will only do hard casting and we bind to our element
            return (HorizontalAlignment)value;             
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
