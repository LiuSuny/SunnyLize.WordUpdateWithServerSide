

using SunnyLize.Word.Core;
using System;
using System.Globalization;
using System.Windows;

namespace SunnyLize.Word
{
    /// <summary>
    /// Menu item type visibility converter that takes in <see cref="MenuItemType"/>
    /// and return a <see cref="Visibility"/> base on a parameter being the same as menu item type
    /// </summary>
    public class MenuItemTypeVisibilityConverter : BaseValueConverter<MenuItemTypeVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if we have no parameter return invisible
            if (parameter == null)

                return Visibility.Collapsed;

            //Try convert parameter string to enum
            if (!Enum.TryParse(parameter as string, out MenuItemType type)) //if this fail to convert then return visibility collaspsed -invisibile
                return Visibility.Collapsed;

            //Otherwise if the parameter matches the type return visible
            return (MenuItemType)value == type ? Visibility.Visible : Visibility.Collapsed;

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
