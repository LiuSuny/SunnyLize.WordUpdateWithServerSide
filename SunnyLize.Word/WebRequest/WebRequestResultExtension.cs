using Dna;
using SunnyLize.Word.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static SunnyLize.Word.DI;


namespace SunnyLize.Word
{
    /// <summary>
    /// Extension method for api <see cref="WebRequestResultExtension"/> class
    /// </summary>
    public static class WebRequestResultExtension
    {
        /// <summary>
        /// Display error if web request fail and display then if they any
        /// </summary>
        /// <typeparam name="T">the type of api response</typeparam>
        /// <param name="response">the response from the server</param>
        /// <param name="title">The titile of the error dialog if there an error</param>
        /// <returns>return true if they was an error or false if they were ok</returns>
        public static async Task<bool> DisplayErrorIfFailedAsync<T>(this WebRequestResult <ApiResponse<T>> response, string title)
        {

            //if there was no response, bad data or a response with error message
            if (response == null || response.ServerResponse == null || !response.ServerResponse.Successful)
            {
                //defualt error message
                //Todo: localize string
                var message = "Unknowm error from server call";

                //if we actual get a response from server
                if (response?.ServerResponse != null)

                    //set messsage to server response
                    message = response.ServerResponse.ErrorMessage;

                //if we have a result but deserialize failed 
                else if (string.IsNullOrWhiteSpace(response?.RawServerResponse))

                    //set error message
                    message = $"Unexpected response from server { response.RawServerResponse}";

                //if we have result but no server response at all then
                else if (response != null)

                    //set message to standard HTTP server response details
                    message = $"Failed to communicate with server.. status code { response.StatusCode}. { response.StatusDescription}";

                //Display error message
                await UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    //TODO: localize string
                    Title = title,
                    Message = message

                });
                //return true if there is an error
                return true;
            }

            //if all is ok then return false if there is no error
            return false;

        }
    }
}
