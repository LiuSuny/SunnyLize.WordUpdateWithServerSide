
using System;
using System.Windows;
using System.Windows.Controls;

namespace SunnyLize.Word
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        #region Private member
        /// <summary>
        /// View model for this window
        /// </summary>
        private DialogWindowViewModel mViewModel;
        #endregion

        #region Public properties



        /// <summary>
        /// The view model getter and setter for this window
        /// </summary>
        public DialogWindowViewModel ViewModel
        {
            get => mViewModel;
            set
            {
                mViewModel = value;

                //Update the view model each time there is changes
                DataContext = mViewModel;
            }
        }
        #endregion


        #region Constructor
        /// <summary>
        /// default ctor
        /// </summary>
        public DialogWindow()
        {
            InitializeComponent();
            //this.DataContext = new DialogWindowViewModel(this);


        }


        #endregion
    }
}
