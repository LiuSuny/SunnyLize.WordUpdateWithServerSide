

using System;
using System.Runtime.CompilerServices;

namespace SunnyLize.Word.Core
{ 
    /// <summary>
    /// Holds a bunch of loggers to log messages for the users
    /// </summary>
    public interface ILogFactory
    {

       
        #region properties

        /// <summary>
        /// The level of logging to output
        /// This can be set to informative etc 
        /// </summary>
        LogOutPutLevel LogOutputLevel { get; set; }

        /// <summary>
        /// If true, includes the origin of where the log message was logged from
        /// such as the class name, line number and file name
        /// </summary>
         bool IncludeLogOriginDetails { get; set; }
        #endregion

        #region Events
        /// <summary>
        /// This event fire whenever a new log arrives
        /// </summary>
        event Action<(string Message, LogLevel Level)> NewLog;
        #endregion


        #region Method

        /// <summary>
        /// Add specific logger to this factory
        /// </summary>
        /// <param name="logger">the logger</param>
        void AddLogger(ILogger logger);

        /// <summary>
        /// remove specific logger to this factory
        /// </summary>
        /// <param name="logger">the logger</param>
        void RemoveLogger(ILogger logger);

        /// <summary>
        /// log the specific logger from this factory
        /// </summary>
        /// <param name="message">the message to log</param>
        /// <param name="level">the level the message being log</param>
        /// <param name="origin">where it happen exactly, the method/function the message was logged in </param>
        /// <param name="filePath"> the codd filename the message was logged from </param>
        /// <param name="lineNumber">the line number filename the message was logged from </param>
        void Log(string message, LogLevel level = LogLevel.Informative, [CallerMemberName]string origin = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0);

        #endregion
    }
}
