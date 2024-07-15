

using SunnyLize.Word.Core;
using System;
using System.Globalization;

namespace SunnyLize.Word
{
    // <summary>
    /// converter that takes in <see cref="IconType"/> return
    /// fontawesome string fr that icon
    /// </summary>
    public class IconTypeToFontAwesomeConverter : BaseValueConverter<IconTypeToFontAwesomeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((IconType)value).ToFontAwesome();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
