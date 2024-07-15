
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace SunnyLize.Word
{
    /// <summary>
    /// Markupextension in xaml is a way of obtaining value that non primitive or specific in xaml
    /// And this the same when we type staticRource and binding
    /// A base value converter that allow us direct xaml usage
    /// </summary>
    /// <typeparam name="T">The type of this value converter</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T: class, new()
    {
        #region Private static member
        /// <summary>
        /// A single static instance of this value converter- the reference to our converter
        /// </summary>
        private static T mConverter = null; //the reference to our converter
        #endregion

        #region Public Override Markup Extension Methods

        /// <summary>
        /// provide  a static instance of the value converter
        /// </summary>
        /// <param name="serviceProvider">The service provide</param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            //way of creating new value of whatever that are pass in
            //if (mConverter == null)
            //    mConverter = new T();
            //return mConverter;
            return mConverter ?? (mConverter = new T()); // this one line code is the same thing like the one above
        }
        #endregion

        #region Value Converter Methods
        /// <summary>
        /// The method to convert one type to another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// The method to convert a value back to it source type (the original type)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
