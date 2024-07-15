

using SunnyLize.Word.Core;
using System;
using System.Globalization;
using System.Threading.Tasks;
using static SunnyLize.Word.DI;

namespace SunnyLize.Word
{
    /// <summary>
    /// Our application state of view model
    /// <summary>
    
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// The current page login appliaction
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login; //Once we change it ApplicationPage.Login our login animation will appear


        /// <summary>
        /// The view model to use for the current page when the current page changes
        /// NOTE: this is not a live  up-date  view model of the current page
        /// It is simply to used to set the view model of the current page at the time of changes 
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        /// <summary>
        /// True if the side menu should be show or not
        /// </summary>
        public bool SideMenuVisible { get; set; } = false; //false to login and chat message


        /// <summary>
        /// True if the setting menu should be show or not
        /// </summary>
        public bool SettingsMenuVisible { get; set; } 


        /// <summary>
        /// Method help us to navigate to specific page
        /// </summary>
        /// <param name="page">The page to go to</param>
        /// <param name="viewModel">The view model, if any, to set explicity t the  new page</param>
        /// <exception cref="NotImplementedException"></exception>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            //Alway hide the setting page if we are changing pages
            SettingsMenuVisible = false;

            //set the view model
            CurrentPageViewModel = viewModel;

            
            //set the current page
            CurrentPage = page;

            //Fire off a current page  changed event
            OnPropertyChanged(nameof(CurrentPage));

            //show side menu or not?
            SideMenuVisible = page == ApplicationPage.Chat;
        }

        /// <summary>
        /// Handle what happen when we have successful login
        /// </summary>
        /// <param name="loginResult">Result for sucessful login</param>
        public async Task  HandleSuccessfulLoginAsync(LoginResultApiModel loginResult)
        {
            await ClientDataStore.SaveLoginCredentialAsync(new LoginCredentialDataModel
            {
                Email = loginResult.Email,
                FirstName = loginResult.FirstName,
                LastName = loginResult.LastName,
                Username = loginResult.Username,
                Token = loginResult.Token
            });

            //Load new setting
            await ViewModelSettings.LoadAsync();

            #region Populating Dumning Data inside settingModel
            // var getLoginDetail =  IOCContainer.ClientDataStore.GetLoginCredentialsAsync();

            //IOCContainer.Settings.Name = new TextEntryViewModel { Label = "Name", OriginalText = $"{userData.FirstName} {userData.LastName}" };
            //IOCContainer.Settings.Username = new TextEntryViewModel { Label = "Usernname", OriginalText = userData.Username };
            //IOCContainer.Settings.Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
            //IOCContainer.Settings.Email = new TextEntryViewModel { Label = "Email", OriginalText = userData.Email }; 
            #endregion

            //Go to chat page
            ViewModelApplication.GoToPage(ApplicationPage.Chat);
            //var email = this.Email;

            ////Note: Never store unsecure [password in variable like this
            //var pass = (parameter as IHavePassword).SecurePassword.UnSecure();
        }
    }
}
