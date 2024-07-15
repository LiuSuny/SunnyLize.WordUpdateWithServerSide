

using System;
using System.Globalization;
using SunnyLize.Word.Core;

namespace SunnyLize.Word
{
    /// <summary>
    /// A converter that takes in a <see cref="BaseViewModel"/> and return UI specific
    /// that should bind with this type of viewmodel
    /// </summary>
    public class PopupContentConverter : BaseValueConverter<PopupContentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ChatAttachmentPopupMenuViewModel basePopup)
                return new VerticalMenu { DataContext = basePopup.Content };

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
