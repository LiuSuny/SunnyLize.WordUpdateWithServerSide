using System.Linq;
using System.Threading.Tasks;
using SunnyLize.Word.Core;


namespace SunnyLize.Word.Relational
{
    /// <summary>
    /// store and retrieve information about the client application
    /// such as login credentials, messages setting  and so on
    /// store in Sqlite database
    /// </summary>
    public class BaseClientDataStore : IClientDataStore
    {
        #region protected property
        /// <summary>
        /// database context for client store
        /// </summary>
        protected ClientDataStoreDbContext mDbContext;
        #endregion



        #region Constructor      
        /// <summary>
        /// default ctor
        /// </summary>
        /// <param name="dbContext">The database to use</param>
        public BaseClientDataStore(ClientDataStoreDbContext dbContext)
        {
            //set local memeber
            mDbContext = dbContext;
        }
        #endregion


        #region Interface implementation
        /// <summary>
        /// determine whether the current user has login credentials
        /// </summary>
        public async Task<bool> HasCredentialsAsync()
        {
            return await GetLoginCredentialsAsync() != null;
        }

        /// <summary>
        /// This determine if our database exist
        /// and make sure the client data store is set up correctly
        /// </summary>
        /// <return>return a task that will finish once setup is completed</return>
        public async Task EnsureDataStoreAsync()
        {
            // Make sure the database exists and is created
              await mDbContext.Database.EnsureCreatedAsync();
        }
        /// <summary>
        /// Get the store login credential for this  client
        /// </summary>
        /// <returns>return the login credential if they exist or null if not exist</returns>

        public Task<LoginCredentialDataModel> GetLoginCredentialsAsync()
        {
            // Get the first column in the login credentials table, or null if none exist
            return Task.FromResult(mDbContext.loginCredentials.FirstOrDefault());
        }
        /// <summary>
        /// Store the given login credential to the backing of data store
        /// </summary>
        /// <param name="login">the login credential to save</param>
        /// <returns>return a task that will finished once save is completed</returns>
        public async Task SaveLoginCredentialAsync(LoginCredentialDataModel loginCredentials)
        {
            //Note that they several way to save our passin credential into our db 
            //first Clear all entries
            mDbContext.loginCredentials.RemoveRange(mDbContext.loginCredentials);
            //if it is sql we can use TRUNCATE TABLE (TABLENAME) 

            //Add new entries
            mDbContext.loginCredentials.Add(loginCredentials);

            //Save changes once added
             await mDbContext.SaveChangesAsync();

        }


        #endregion
    }
}
