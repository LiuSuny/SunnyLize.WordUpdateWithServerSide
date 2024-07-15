
using System.Runtime.InteropServices;
using System;
using System.Windows;
using System.Windows.Input;
using System.Security;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dna;
using SunnyLize.Word.Core;
using static SunnyLize.Word.DI;


namespace SunnyLize.Word
{
    
    /// <summary>
    /// View model for a login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
       
        #region public properties
        /// <summary>
        /// the email of the user
        /// </summary>
       public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
       public bool LoginIsRunning { get; set; }

        #endregion 

        
        #region Commands
        
        /// <summary>
        /// the command users login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// the command to register for new account
        /// </summary>
        public ICommand RegisterCommand { get; set; }
        #endregion


        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public LoginViewModel()
        {
            
            //Creating a command
            LoginCommand = new RelayParameterizedCommand( async (parameter) => await LoginAsync(parameter)); 
           RegisterCommand = new RelayCommand(async() => await RegisterAsync()); 
           
        }
         
      
        #endregion

        #region User Login Task Method
        /// <summary>
        /// Attemt to log the user in
        /// </summary>
        /// <param name="parameter">The securestring pass in from the view for the user password</param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {
            //if (LoginIsRunning)
            //        return;

            // LoginIsRunning = true;
            await RunCommandAsync(() => this.LoginIsRunning, async () =>
             {

            //Call server attempt when it time to login with credentials
            //Move all URLS and API routes to static in core
            var result = await WebRequests.PostAsync<ApiResponse<LoginResultApiModel>>(
                "http://localhost:5000/api/login",
                new LoginCredentialApiModel
                     {
                         UsernameOrEmail = Email,
                         Password = (parameter as IHavePassword).SecurePassword.UnSecure()
                     });

                 //if there was no response, bad data or a response with error message
                 if (await result.DisplayErrorIfFailedAsync("Login Failed"))
                     return;

                 //if we pass the above stage then it time to get real user data for sucessful login
                 //Ok successfuly logged in..now get the user data
                 var loginResult = result.ServerResponse.Response;
                
                 //let the application view model handlewhat happen with sucessful login
                 await ViewModelApplication.HandleSuccessfulLoginAsync(loginResult);
            });
                //LoginIsRunning = false;

        }
        #endregion

        #region User Registeration Task Method
        /// <summary>
        /// Takes the user to register page 
        /// </summary>
        /// <returns></returns>
        public async Task RegisterAsync()
        {
            //IOCContainer.Application.SideMenuVisible ^= true;
            //return;


            // go register page
            //((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Register;
          
            ViewModelApplication.GoToPage(ApplicationPage.Register);
            
                
            await Task.Delay(1);

                     
        }
        #endregion
    }
}
