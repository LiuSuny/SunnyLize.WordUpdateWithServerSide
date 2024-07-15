using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// store and retrieve information about the client application
    /// such as login credentials, messages setting  and so on
    /// </summary>
    public interface IClientDataStore
    {
        /// <summary>
        /// determine whether the current user has loggin credentials
        /// </summary>
       // Task<bool> HasCredentials();
        Task<bool> HasCredentialsAsync();


        /// <summary>
        /// This determine if our database exist
        /// and make sure the client data store is set up correctly
        /// </summary>
        /// <return>return a task that will finish once setup is completed</return>
        //Task EnsureDataStoreAsync();
        Task EnsureDataStoreAsync();

        /// <summary>
        /// Get the store login credential for this  client
        /// </summary>
        /// <returns>return the login credential if they exist or null if not exist</returns>
        //Task<LoginCredentialDataModel> GetLoginCredentialsAsync();
        Task<LoginCredentialDataModel> GetLoginCredentialsAsync();

        /// <summary>
        /// Store the given login credential to the backing of data store
        /// </summary>
        /// <param name="login">the login credential to save</param>
        /// <returns>return a task that will finished once save is completed</returns>
        //Task SaveLoginCredentialAsync(LoginCredentialDataModel loginCredentials);
        Task SaveLoginCredentialAsync(LoginCredentialDataModel loginCredentials);

    }
}
