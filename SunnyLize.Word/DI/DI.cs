using Dna;
using SunnyLize.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunnyLize.Word
{
    /// <summary>
    /// Shortcut to access class to get DI service with nice clean short code
    /// </summary>
    public static class DI
    {
        /// <summary>
        /// shortcut to access the <see cref="IUIManager"/>
        /// </summary>
        public static IUIManager UI => Framework.Service<IUIManager>(); //just a sort of shortcut to reach the IUIManager

        /// <summary>
        /// shortcut allow us access for shortcut the <see cref="ApplicationViewModel"/>
        /// </summary>
        public static ApplicationViewModel ViewModelApplication => Framework.Service<ApplicationViewModel>();  //just a sort of shortcut to reach the ApplicationViewModel

        /// <summary>
        /// shortcut allow us access for shortcut the <see cref="SettingsViewModel"/>
        /// </summary>
        public static SettingsViewModel ViewModelSettings => Framework.Service<SettingsViewModel>();  //just a sort of shortcut to reach the IUIManager

        /// <summary>
        /// shortcut to access <see cref="IClientDataStore"/> service
        /// </summary>      
        public static IClientDataStore ClientDataStore => Framework.Service<IClientDataStore>();


    }
}
