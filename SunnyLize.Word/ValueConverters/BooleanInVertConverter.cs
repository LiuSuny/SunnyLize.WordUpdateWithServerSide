


using System;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;


namespace SunnyLize.Word
{
    /// <summary>
    /// A converter that takes in a boolean and invert it back 
    /// </summary>
    public class BooleanInVertConverter : BaseValueConverter<BooleanInVertConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value; //not boolean value
        

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
        
    }
}
