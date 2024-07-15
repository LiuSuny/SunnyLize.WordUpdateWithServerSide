

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// The the level of output message to log in for a logger
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Developer specific information
        /// </summary>
       Debug = 1, 

       /// <summary>
       /// Verbose information
       /// </summary>
       Verbose = 2,

       /// <summary>
       /// General information
       /// </summary>
       Informative = 3,
       
       /// <summary>
       /// warning
       /// </summary>
       Warning = 4,

        /// <summary>
        /// warning
        /// </summary>
        Error = 5,

        /// <summary>
        /// warning
        /// </summary>
        Success = 6,
     
    }
}
