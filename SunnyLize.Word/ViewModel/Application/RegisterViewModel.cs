using Dna;
using SunnyLize.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static SunnyLize.Word.DI;


namespace SunnyLize.Word
{
    /// <summary>
    /// View model for a register screen
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {

        #region public properties
        /// <summary>
        /// the email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// the username of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool RegisterIsRunning { get; set; }

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
        public RegisterViewModel()
        {

            //Creating a command
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await RegisterAsync(parameter));
            LoginCommand = new RelayCommand(async () => await LoginAsync());
           
        }



        #endregion

        #region User Login Task Method
        /// <summary>
        /// Attempt to register the user in
        /// </summary>
        /// <param name="parameter">The securestring pass in from the view for the user password</param>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter)
        {

            await RunCommandAsync(() => this.RegisterIsRunning, async () =>
            {
                //Call server attempt when it time to registered with provided credentials
                //Move all URLS and API routes to static in core
                var result = await WebRequests.PostAsync<ApiResponse<RegisterResultApiModel>>(
                    "http://localhost:5000/api/register",
                    new RegisterCredentialsApiModel
                    {
                        Username = Username,
                        Email = Email,                      
                        Password = (parameter as IHavePassword).SecurePassword.UnSecure()
                    });

                //Instead of doing all the error check here we created an  extension which handle all the check error and suceessful response from our web request api
                //if the response has error...
                if (await result.DisplayErrorIfFailedAsync("Register Failed"))
                    //we are done
                    return;
            
                //if we pass the above stage then it time to get real user data for sucessful login
                //Ok successfuly logged in..now get the user data
                var loginResult = result.ServerResponse.Response;

                //let the application view model handle what happen with sucessful registeration
                await ViewModelApplication.HandleSuccessfulLoginAsync(loginResult);

            });


        }
        #endregion

        #region User Registeration Task Method
        /// <summary>
        /// Takes the user to login page 
        /// </summary>
        /// <returns></returns>
        public async Task LoginAsync()
        {
            //IOCContainer.Application.SideMenuVisible ^= true;
            //return;


            // go register page
            //((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Register;

            ViewModelApplication.GoToPage(ApplicationPage.Login);


            await Task.Delay(1);


        }
        #endregion


      
    }
}
