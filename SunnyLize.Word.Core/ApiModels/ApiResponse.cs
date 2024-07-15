using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// repsonse for all web api call made
    /// </summary>
    public class ApiResponse<T>
    {
        #region public property
        /// <summary>
        /// these property indicate if api calls was sucessful
        /// </summary>
        public bool Successful => ErrorMessage == null;

        /// <summary>
        /// error message for failed api calls
        /// </summary>
        public string ErrorMessage { set; get; }

        /// <summary>
        /// the api response object
        /// </summary>
        public T Response { set; get; }
        #endregion
    }
}
