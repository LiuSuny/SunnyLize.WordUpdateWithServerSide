

using System;
using System.Windows;

namespace SunnyLize.Word
{
    /// <summary>
    /// Base attached property to replace the Sunnylize WPF attached property
    /// </summary>
    /// <typeparam name="Parent">parent to be the attched property</typeparam>
    /// <typeparam name="Property">the type of this attached property(boolean)</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent :/* BaseAttachedProperty<Parent, Property>,*/ new() //this tell class that parent is the new instance class 
    {
        #region public Event Listener
        /// <summary>
        /// Fired the event when the value change
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs>
            ValueChanged = (sender, e) => { };


        /// <summary>
        /// Fired the event when the value change even when the value are the same
        /// </summary>
        public event Action<DependencyObject, object>
            ValueUpdated = (sender, value) => { };
        #endregion


        #region public properties
        //Needed an instance  of our attached property
        /// <summary>
        /// A singleton instance of our parent class
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #region Attached Property Definitions

        /// <summary>
        /// The actual Attached property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(Property),
                typeof(BaseAttachedProperty<Parent, Property>),
                new UIPropertyMetadata( default(Property),
                    new PropertyChangedCallback(OnValuePropertyChanged), 
                    new CoerceValueCallback(OnValuePropertyUpdated)
                    ));

        /// <summary>
        /// The callback event when <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d">The UI element that had it's property changed</param>
        /// <param name="e"> The argument for the event</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //call the parent function 
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnvalueChanged(d, e);

            //call event listener
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(d, e);
        }


        /// <summary>
        /// The callback event when <see cref="ValueProperty"/> is changed even if the same value
        /// </summary>
        /// <param name="d">The UI element that had it's property changed</param>
        /// <param name="e"> The argument for the event</param>
        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            //call the parent function 
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnvalueUpdated(d, value);

            //call event listener
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueUpdated(d, value);

            //return value
            return value;
        }


        /// <summary>
        /// Gets the attached property
        /// </summary>
        /// <param name="d">this is the element we get property from </param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);
        //{
        //    return (Property)d.GetValue(ValueProperty);
        //}

        /// <summary>
        /// The set the attached property
        /// </summary>
        /// <param name="d">the element to get the property from</param>
        /// <param name="value">the value to set the property to</param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);




        #endregion

        #region Events Method

        /// <summary>
        /// This method is called when any attached property of this type is changed
        /// </summary>
        /// <param name="sender">The Ui element that this property was cahnged for</param>
        /// <param name="e">The argument for this event</param>
        public virtual void OnvalueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }


        /// <summary>
        /// This method is called when any attached property of this type is changed even if the value is the same
        /// </summary>
        /// <param name="sender">The Ui element that this property was cahnged for</param>
        /// <param name="e">The argument for this event</param>
        public virtual void OnvalueUpdated(DependencyObject sender, object value) { }
        #endregion

    }
}
