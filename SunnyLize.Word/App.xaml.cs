using Dna;
using SunnyLize.Word.Core;
using SunnyLize.Word.Relational;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using static SunnyLize.Word.DI;
using static Dna.FrameworkDI;

namespace SunnyLize.Word
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Customize startup so we can load our IOC container immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnStartup(StartupEventArgs e)
        {


            //We are allowing the base appliaction do what it need
            base.OnStartup(e);

            //Setup the main application
            await ApplicationSetUpAsync();

            //Log it
            Logger.LogDebugSource("This is debug...");

            //Set up the application if we are login or not 
            ViewModelApplication.GoToPage(
                //if we are login...
                //await IOCContainer.ClientDataStores.HasCredentialsAsync()
                await ClientDataStore.HasCredentialsAsync()

                //go to chat page
                ? ApplicationPage.Chat
                //if not login then go to login page
                : ApplicationPage.Login);




            //Next we show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();


        }

        /// <summary>
        /// Configure our application ready for use
        /// </summary>
        private async Task ApplicationSetUpAsync()
        {
            //Setup the Dna Framework
            Framework.Construct<DefaultFrameworkConstruction>()
                .AddFileLogger()
                .AddClientDataStore()
                .AddSunnyLizeWordViewModel()
                .AddSunnyLizeWordClientServices()
                .Build();

            

            

           

            
           

                  //ensure client data store
            await ClientDataStore.EnsureDataStoreAsync();

            // Load new setting
            await ViewModelSettings.LoadAsync();
        }
    }
}
