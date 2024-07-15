

using SunnyLize.Word.Core;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SunnyLize.Word
{
    /// <summary>
    /// base class for any content that is being use inside the <see cref="DialogWindow"/>
    /// </summary>
    public class BaseDialogUserControl : UserControl
    {
        #region Private Member

        /// <summary>
        /// The dialog window we will be contained within
        /// </summary>
        private DialogWindow mDialogWindow;


        #endregion

        #region Public Command

        /// <summary>
        /// Ability to close this dialog
        /// </summary>
        public ICommand CloseCommand { get; private set; }
        #endregion

        #region Public properties

        /// <summary>
        /// The window min width of this dialog
        /// </summary>
        public int WindowMinimiumWidth { get; set; } = 250;

        /// <summary>
        /// The window min height of this dialog
        /// </summary>
        public int WindowMinimumHeight { get; set; } = 100;

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 30;

        /// <summary>
        /// the dialog title 
        /// </summary>
        public string Title { get; set; }
        #endregion


        #region Constructor
        /// <summary>
        /// default ctor
        /// </summary>
        public BaseDialogUserControl()
        {
            //setting the new instance of dialog by creating it
            mDialogWindow = new DialogWindow();

            mDialogWindow.ViewModel = new DialogWindowViewModel(mDialogWindow);

            //Create a close command
            CloseCommand = new RelayCommand(() => mDialogWindow.Close());


        }
        #endregion

        #region Public Dialog Show Methods

        /// <summary>
        /// Displaying a simple message box to the user
        /// Using generic t call the message
        /// Task is use because we need to await when the task is close 
        /// </summary>
        /// <param name="viewModel">View model</param>
        /// <typeparam name="T">The view model type  for this control</typeparam>
        /// <returns></returns>
        public Task ShowDialog<T>(T viewModel)
             where T : BaseDialogViewModel
        {
            //Since will ceate a task and we need to await close we implement the following
            var tcs = new TaskCompletionSource<bool>(); //we created a new job once copmleted

            //Run on UI thread
            Application.Current.Dispatcher.Invoke(() => //this basically will calla dn run this the below action
            {
                try
                {

                    //viewModel.Title = string.Empty; //checking the presidency if our view model doesn't  have a title we can construct our title as we want


                    // Match controls expected sizes to the dialog windows view model
                    mDialogWindow.ViewModel.WindowMinimiumWidth = WindowMinimiumWidth;
                    mDialogWindow.ViewModel.WindowMinimumHeight = WindowMinimumHeight;
                    mDialogWindow.ViewModel.TitleHeight = TitleHeight;
                    //mDialogWindow.ViewModel.Title = viewModel.Title ?? Title;

                    mDialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                    //Set this dialog to the dialog content window
                    mDialogWindow.ViewModel.Content = this;

                    //Setup this controls data context binding to the view model
                    DataContext = viewModel;

                    //Show in the center of the parent
                    mDialogWindow.Owner = Application.Current.MainWindow;
                    mDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                    //Show dialog
                    mDialogWindow.ShowDialog();
                }
                finally
                {
                    //This let the caller know we have finished
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }
        #endregion
    }
}
