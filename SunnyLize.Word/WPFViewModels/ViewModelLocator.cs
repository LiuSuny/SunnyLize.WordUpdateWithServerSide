using SunnyLize.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SunnyLize.Word.DI;

namespace SunnyLize.Word
{
    /// <summary>
    /// Locate view models from the IOC for use in binding in xaml file
    /// </summary>
    public class ViewModelLocator
    {
        #region Public property
        /// <summary>
        /// Public singleton instance locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();
       
        /// <summary>
        /// the appliaction view model
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => ViewModelApplication;

        /// <summary>
        /// the setting view model
        /// </summary>
        public static SettingsViewModel SettingsViewModel => ViewModelSettings;
        #endregion
    }
}
