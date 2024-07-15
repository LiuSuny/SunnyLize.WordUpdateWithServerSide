using Dna;
using Microsoft.Extensions.DependencyInjection;
using SunnyLize.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunnyLize.Word
{
    /// <summary>
    /// This is the extension method for the <see cref="FrameworkConstruction"/> 
    /// </summary>
    public static class FrameworkConstructionExtensions
    {

        /// <summary>
        /// Inject the view model for sunnylize word application
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddSunnyLizeWordViewModel(this FrameworkConstruction construction)
        {


            //Binding to a single instance of Application view model
            construction.Services.AddSingleton<ApplicationViewModel>();

            //Binding to a single instance of settings view model
            construction.Services.AddSingleton<SettingsViewModel>();

            //return the construction chaining
            return construction;
            
        }

        /// <summary>
        /// Inject the view model for sunnylize word client services
        /// needed for SunnyLize word application
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddSunnyLizeWordClientServices(this FrameworkConstruction construction)
        {
            //Add our task manager
            construction.Services.AddTransient<ITaskManager, BaseTaskManager>();
            //Bind a file manager
            construction.Services.AddTransient<IFileManager, BaseFileManager>();

            //Bind the UI manager
            
            construction.Services.AddTransient<IUIManager, UIManager>();

            //return the construction chaining
            return construction;
        }
    }
}
