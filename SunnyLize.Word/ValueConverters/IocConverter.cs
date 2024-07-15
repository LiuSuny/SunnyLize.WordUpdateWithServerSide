


using SunnyLize.Word.Core;
using System;
using System.Diagnostics;
using System.Globalization;
using static SunnyLize.Word.DI;


namespace SunnyLize.Word
{
    /// <summary>
    /// Converts a string name to a service pull from the ioc container
    /// </summary>
    public class IocConverter : BaseValueConverter<IocConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Finding the appropriate page
            switch ((string)parameter)
            {
                case nameof(ApplicationViewModel):
                    return ViewModelApplication;

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
