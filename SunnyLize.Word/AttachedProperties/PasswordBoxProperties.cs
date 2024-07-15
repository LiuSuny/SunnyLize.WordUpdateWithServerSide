
using System;
using System.Windows;
using System.Windows.Controls;

namespace SunnyLize.Word
{
    #region AttachedRegisterProperties
    public class PasswordBoxProperties
    {
       //// public bool HasText { get; set; } = false;

       // //Proper way of doing attached property
       // public static readonly DependencyProperty MonitorPasswordProperty =
       //     DependencyProperty.RegisterAttached("MonitorPassword", typeof(bool),
       //         typeof(PasswordBoxProperties), new PropertyMetadata(false, OnMonitorPasswordChanged));

       // private static void OnMonitorPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
       // {
       //     var passwordbox = (d as PasswordBox);
       //     if (passwordbox == null) return;
       //     passwordbox.PasswordChanged -= passwordBox_PasswordChange;

       //     if ((bool)e.NewValue)
       //     {
       //         SetHasText(passwordbox);
       //         passwordbox.PasswordChanged += passwordBox_PasswordChange;
       //     }
       // }

       // private static void passwordBox_PasswordChange(object sender, RoutedEventArgs e)
       // {
       //     SetHasText((PasswordBox)sender);
       // }

       // //attached property Setter
       // public static void SetMonitorPassword(PasswordBox element, bool value)
       // {
       //     element.SetValue(MonitorPasswordProperty, value);
       // }

       // //Attached property Getter
       // public static bool GetMonitorPassword(PasswordBox element)
       // {
       //    return (bool)element.GetValue(MonitorPasswordProperty);
       // }




       // public static readonly DependencyProperty HasTextProperty =
       //   DependencyProperty.RegisterAttached("HasText", typeof(bool),
       //       typeof(PasswordBoxProperties), new PropertyMetadata(false));

       // private static void SetHasText(PasswordBox element)
       // {
       //     element.SetValue(HasTextProperty, element.SecurePassword.Length > 0);
       // }

       // public static bool GetHasText(PasswordBox element)
       // {
       //     return (bool)element.GetValue(HasTextProperty);
       // }
    }
    #endregion
}
