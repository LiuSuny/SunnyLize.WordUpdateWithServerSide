
using System.Runtime.InteropServices;
using System;
using System.Windows;
using System.Windows.Input;
using SunnyLize.Word.Core;
using System.Windows.Controls;

namespace SunnyLize.Word
{
    
    /// <summary>
    /// View model for the custom dialog window
    /// </summary>
    public class DialogWindowViewModel : WindowViewModel
    {

        #region public properties

        /// <summary>
        /// the title of this dialog window
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// the content to host inside the dialog
        /// </summary>
        public Control Content { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// default ctor
        /// </summary>
        /// <param name="window"></param>
        public DialogWindowViewModel(Window window) : base(window) 
        {
            //Overidden the minwidth and minheight window to smaller than our mainwindow
            WindowMinimiumWidth = 250;
            WindowMinimumHeight = 100;

            //Making title height smaller
            TitleHeight = 30;
        }
        

        #endregion

    }
}
