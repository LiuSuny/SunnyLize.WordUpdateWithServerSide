using SunnyLize.Word.Core;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;


namespace SunnyLize.Word
{
    /// <summary>
    /// Interaction logic for PasswordEntryControl.xaml
    /// </summary>
    public partial class PasswordEntryControl : UserControl
    {
        #region Dependency Properties
        /// <summary>
        /// Label width of the control using (DI)
        /// </summary>
        public GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

        // Using a DependencyProperty as the backing store for LabelWidth.  This enables animation, styling, binding, etc...
        //
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength),
                typeof(PasswordEntryControl), new PropertyMetadata(GridLength.Auto, LabelWidthChangeCallBack));

        #endregion


        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public PasswordEntryControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Dependency Labels callback 
        /// <summary>
        /// Called when the label is changed
        /// </summary>
        /// <param name="d">instance of control</param>
        /// <param name="e">the value</param>
        private static void LabelWidthChangeCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //incase of user typing invalid property we first of rap it with try catch
            try
            {
                //Next we try to convert the string to valid grid length
                //var gridLength = (GridLength)new GridLengthConverter().ConvertFromString((string)e.NewValue);


                //We set the column definition to new value
                (d as PasswordEntryControl).LabelColumnDefintion.Width = ((GridLength)e.NewValue);


            }
            catch (Exception)
            {
                //Make developer aware of potential issue incase user enter invalid property
                Debugger.Break();

                //Afterward we set it to normal which take the original auto property
                (d as PasswordEntryControl).LabelColumnDefintion.Width = GridLength.Auto;
            }
        }
        #endregion

        /// <summary>
        /// Update the view model with the current password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //Update view model
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.CurrentPassword = CurrentPassword.SecurePassword;

        }
       
        private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //Update view model
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.NewPassword = NewPassword.SecurePassword;
        }

        private void ConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //Update view model
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.ConfirmPassword = ConfirmPassword.SecurePassword;
        }

    }
}
