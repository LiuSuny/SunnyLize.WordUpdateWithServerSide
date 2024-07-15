
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SunnyLize.Word.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Web;

namespace SunnyLize.Word.Web.Server
{

    /// <summary>
    /// Manages the web API Calls
    /// </summary>
    public class ApiController : Controller
    {
        //public byte[] Encoding { get; private set; }

        #region Protected Properties
        /// <summary>
        /// Scoped application context
        /// </summary>
        protected ApplicationDbContext mContext;

        /// <summary>
        /// the manager for handling user creation, delete, serach, roles and others
        /// </summary>
        protected UserManager<ApplicationUser> mUserManager;

        /// <summary>
        /// Manager for signing and in and out for our users
        /// </summary>
        protected SignInManager<ApplicationUser> mSignInManager;

        #endregion

        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="context">the injected context</param>
        /// <param name="userManager">The identity user manager</param>
        /// <param name="signInManager">The identity sign in manager</param>
        public ApiController(
          ApplicationDbContext context,
          UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            mContext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }

        #endregion

        #region Register User


        /// <summary>
        /// Try to register new user account on the server
        /// </summary>
        /// <param name="registerCredentials">register user credential</param>
        /// <return>Return the result of Register request</return>
        [Route("api/register")]
        public async Task<ApiResponse<RegisterResultApiModel>>
            RegisterAsync([FromBody]RegisterCredentialsApiModel registerCredentials)
        {

            var inValidErrorMessage = "Please provide all required detail before registering for an account";

            //erorr message for failed register
            var errorResponse = new ApiResponse<RegisterResultApiModel>
            {
                //set error message
                ErrorMessage = inValidErrorMessage
            };

            //if we have no credentials..
            if (registerCredentials == null)
                //or some credentials are missing ...in our startup we implement some checks
                return errorResponse;

            // Make sure we have a user name
            if (string.IsNullOrWhiteSpace(registerCredentials.Username))
                // Return error message to user
                return errorResponse;

            //Create a user from the given detail
            var user = new ApplicationUser
            {
                UserName = registerCredentials.Username,
                FirstName = registerCredentials.FirstName,
                LastName = registerCredentials.LastName,
                Email = registerCredentials.Email
            };

            //we try and create a user
            var result = await mUserManager.CreateAsync(user, registerCredentials.Password);

            //If the registration is successful..
            if (result.Succeeded)
            {
                //Get the user details
                var userIdentity = await mUserManager.FindByNameAsync(user.UserName);
                //Generate a email verification code GenerateChangeEmailTokenAsync and
                //GenerateChangePhoneTokenAsync, GeneratePasswordResetTokenAsync are all method that allow us to generate or get token from our db
                // var emailVerificationCode = await mUserManager.GenerateEmailConfirmationTokenAsync(user);

                await SendUserEmailVerificationAsync(user);
                //// TODO: Replace with APIRoutes that will contain the static routes to use
                //var confirmationUrl = $"http://{Request.Host.Value}/api/verify/email/{HttpUtility.UrlEncode(userIdentity.Id)}/{HttpUtility.UrlEncode(emailVerificationCode)}";

                // Email the user the verification code
                //await SunnyLizeEmailSender.SendUserVerificationEmailAsync(user.UserName, userIdentity.Email, confirmationUrl);
                //Return valid response containing all user details
                return new ApiResponse<RegisterResultApiModel>
                {
                    Response = new RegisterResultApiModel
                    {
                        Username = userIdentity.UserName,
                        FirstName = userIdentity.FirstName,
                        LastName = userIdentity.LastName,
                        Email = userIdentity.Email,
                        Token = userIdentity.GenerateJwtToken()
                    },
                };
            }
            //otherwise we return our api response which handle both error or successful messages
            else
                //return a failed response
                return new ApiResponse<RegisterResultApiModel>
                {
                    //Aggregate all errors into a single error string
                    ErrorMessage = result.Errors?.ToList() //enumerable
              .Select(p => p.Description) //select type of error
              .Aggregate((a, b) => $"{a}{Environment.NewLine}{b}") //add all error together
                };

        }

        #endregion

        #region Login User

        /// <summary>
        /// Try to Login new user account on the server
        /// </summary>
        /// <param name="registerCredentials">login user credential</param>
        /// <return>Return the result of login request</return>
        [Route("api/login")]
        public async Task<ApiResponse<LoginResultApiModel>> LoginAsync([FromBody] LoginCredentialApiModel loginCredentials)
        {
            var inValidErrorMessage = "Invalid username or password";

            //erorr message for failed login
            var errorResponse = new ApiResponse<LoginResultApiModel>
            {
                //set error message
                ErrorMessage = inValidErrorMessage
            };

            // Get the users if the login is correct... 
            //and make sure we have user name or email
            if (loginCredentials?.UsernameOrEmail == null || string.IsNullOrWhiteSpace(loginCredentials.UsernameOrEmail)) //if the username is null or just whitespace or null
                //then return error message
                return errorResponse;

            //validate if the user credential is correct
            // check if it is an email 
            var isEmail = loginCredentials.UsernameOrEmail.Contains("@");
            //get user detail
            var user = isEmail ?
              //find by email
              await mUserManager.FindByEmailAsync(loginCredentials.UsernameOrEmail) :
            //find by username
            await mUserManager.FindByNameAsync(loginCredentials.UsernameOrEmail);

            //if we fail to find the user
            if (user == null)
                //then return error message
                return errorResponse;

            //If we got here if we have user 
            //Then let validate password

            //Get if password is valid
            var inValidPassword = await mUserManager.CheckPasswordAsync(user, loginCredentials.Password);

            //if the password is wrong
            if (inValidPassword)
                //then return error message
                return errorResponse;

            //if we get here, we are valid and the user passed in correct login details
            var username = user.UserName;


            //Return tken to user
            return new ApiResponse<LoginResultApiModel>
            {
                Response = new LoginResultApiModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.UserName,
                    Email = user.Email,
                    Token = user.GenerateJwtToken()  //Get JWT Token

                }

            };
        }
        #endregion

        [AuthorizeToken]
        [Route("api/private")]
        public IActionResult Private()
        {
            var user = HttpContext.User;
            return Ok(new { privataData = $"some secret {user.Identity.Name}" });
        }

        #region Private Helpers

        /// <summary>
        /// Sends the given user a new verify email link
        /// </summary>
        /// <param name="user">The user to send the link to</param>
        /// <returns></returns>
        private async Task SendUserEmailVerificationAsync(ApplicationUser user)
        {
            // Get the user details
            var userIdentity = await mUserManager.FindByNameAsync(user.UserName);

            // Generate an email verification code
            var emailVerificationCode = await mUserManager.GenerateEmailConfirmationTokenAsync(user);

            // TODO: Replace with APIRoutes that will contain the static routes to use
            var confirmationUrl = $"http://{Request.Host.Value}/api/verify/email/?userId={HttpUtility.UrlEncode(userIdentity.Id)}&emailToken={HttpUtility.UrlEncode(emailVerificationCode)}";

            // Email the user the verification code
            //await SunnyLizeEmailSender.SendUserVerificationEmailAsync(user.UserName, userIdentity.Email, confirmationUrl);
        }
        #endregion
    }
}
