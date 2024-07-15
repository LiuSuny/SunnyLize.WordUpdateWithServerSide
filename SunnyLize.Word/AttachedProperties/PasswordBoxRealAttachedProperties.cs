

using System;
using System.Windows;
using System.Windows.Controls;

namespace SunnyLize.Word
{
    /// <summary>
    /// The monitorpassword attached property for a <see cref="PasswordBox"/>
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnvalueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Getting the caller
            var password = sender as PasswordBox;

            //Making sure it is a password box
            if (password == null)
                return;

            //Remove previous event
            password.PasswordChanged -= Password_passwordChanged;

            //if the caller set monitorPassword to trus 
            if ((bool)e.NewValue)
            {
                //Set default value
                HasTextProperty.SetValue(password);
                //start listening out for more password changes
                password.PasswordChanged += Password_passwordChanged;
            }
            
        }

        /// <summary>
        /// Firing the password when the password box changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Password_passwordChanged(object sender, RoutedEventArgs e)
        {
            //Set value for the attached property changes
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }

    /// <summary>
    /// The HasText attached property for a <see cref="PasswordBox"/>
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty/*our source*/, bool/*what type that attached property is*/> 
    {
        /// <summary>
        /// Set the HasText property base on if the caller <see cref="PasswordBox"/> has any text
        /// </summary>
        /// <param name="sender"></param>
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
     








    //public class PasswordBoxRealAttachedProperties
    //{
    //}
}
