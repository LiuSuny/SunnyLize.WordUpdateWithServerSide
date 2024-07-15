
using SunnyLize.Word.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace SunnyLize.Word
{
    /// <summary>
    /// ToBasePage the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public static class ApplicationPageHelpers /* BaseValueConverter<ApplicationPageValueConverter>*/
    {
        /// <summary>
        /// Takes a <see cref="ApplicationPage"/>and a view model, if any and createa desired page
        /// </summary>
        /// <param name="page"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null )
        {
            //Finding the appropriate page
           switch(page)
           {
                case ApplicationPage.Login: 
                    return new LoginPage(viewModel as LoginViewModel);
              
                case ApplicationPage.Register:
                    return new RegisterPage(viewModel as RegisterViewModel);

                case ApplicationPage.Chat:
                    return new ChatPage(viewModel as ChatMessageListViewModel);

                default:
                    Debugger.Break ();
                    return null;
           }

        }

        /// <summary>
        /// this convert a<see cref="BasePage"/> to a specific <see cref="ApplicationPage"/> that is for type of page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static ApplicationPage ToApplicationPage (this BasePage page)
        {
            //switch(page)
            //{
            //    case page is ChatPage 
            //        break;
            //}

            //convert to find application page that matches the base page
            if (page is ChatPage)
                return ApplicationPage.Chat;
            if (page is LoginPage)
                return ApplicationPage.Login;
            if (page is RegisterPage)
                return ApplicationPage.Register;

            //Alert developer of issue
            Debugger.Break();

            return default(ApplicationPage);
        }
      
    }
}
