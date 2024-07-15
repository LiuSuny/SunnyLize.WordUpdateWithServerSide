

using System;
using System.Globalization;
using System.Windows;

namespace SunnyLize.Word
{
    /// <summary>
    /// A converter that takes in a date and convert it to user friendly message read time
    /// </summary>
    public class TimeToReadMessageTimeConverter : BaseValueConverter<TimeToReadMessageTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //First we need to get the time passed in
            var time = (DateTimeOffset)value;

            //If it is not read
            if (time == DateTimeOffset.MinValue)
                //Show nothing
                return string.Empty;

            //Checking if it is today===//if time.date==datetimeoffset.utcnow.date
            if (time.Date == DateTimeOffset.UtcNow.Date)
                //returning just time
                return $"Read { time.ToLocalTime().ToString("HH:mm")}";

            //if it is not today we just want to return full date
            return $"Read {time.ToLocalTime().ToString("HH:mm MM yyyy")}";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
