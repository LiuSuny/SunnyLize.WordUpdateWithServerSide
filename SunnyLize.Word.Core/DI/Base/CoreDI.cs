using Dna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// The Ioc container for our application
    /// </summary>
    public static class CoreDI
    {
        #region public property
            
        /// <summary>
        /// shortcut to access the <see cref="IFileManager"/>
        /// </summary>
        public static IFileManager FileManager => Framework.Service<IFileManager>(); //just a sort of shortcut to reach the IFileManager

        /// <summary>
        /// shortcut to access the <see cref="ITaskManager"/>
        /// </summary>
        public static ITaskManager TaskManager => Framework.Service<ITaskManager>(); //just a sort of shortcut to reach the IUIManager

   
        #endregion

    }
}