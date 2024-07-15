

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// The standard log factory for SunnyLize Word
    /// Logs details to the console by default
    /// </summary>
    public class BaseLogFactory : ILogFactory
    {
        #region Protected 
        /// <summary>
        /// A list of logger in this factory
        /// </summary>
        protected List<ILogger> mLoggers = new List<ILogger>();

        /// <summary>
        /// A lock for the logger to keep it thread safe
        /// </summary>
        protected object  mLoggersLock = new object();
        #endregion

        #region Public Property
        /// <summary>
        /// The level of logging to output
        /// This can be set to informative etc 
        /// </summary>
        public LogOutPutLevel LogOutputLevel { get; set; }

        /// <summary>
        /// If true, includes the origin of where the log message was logged from
        /// such as the class name, line number and file name
        /// </summary>
        public bool IncludeLogOriginDetails { get; set; } = true;
        #endregion

        #region Public event
        /// <summary>
        /// This event fire whenever a new log arrives
        /// </summary>
        public event Action<(string Message, LogLevel Level)> NewLog = (details) => { };
        #endregion

        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="loggers">Loggers to add  to the factory, on top of new stock 
        /// logger alread included</param>
        public BaseLogFactory(ILogger[] loggers = null)
        {
            //Add console logger
            //AddLogger(new ConsoleLogger());
            AddLogger(new DebugLogger());

            //Add any other pass in
            if (loggers != null)
                foreach (var logger in loggers)
                    AddLogger(logger);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Add specific logger to this factory
        /// </summary>
        /// <param name="logger">the logger</param>
        public void AddLogger(ILogger logger)
        {
            //Lock the list so it is thread-safe
            lock (mLoggers)
            {
                //If the logger does not already exist in the list...
                if(!mLoggers.Contains(logger))

                //then add the logger to the list
                mLoggers.Add(logger);
            }
        }


        /// <summary>
        /// remove specific logger to this factory
        /// </summary>
        /// <param name="logger">the logger</param>
        public void RemoveLogger(ILogger logger)
        {
            //Lock the list so it is thread-safe
            lock (mLoggers)
            {
                //If the logger is in the list...
                if (mLoggers.Contains(logger))

                    //then remove the logger from the list
                    mLoggers.Remove(logger);
            }
        }

        /// <summary>
        /// log the specific logger from this factory
        /// </summary>
        /// <param name="message">the message to log</param>
        /// <param name="level">the level the message being log</param>
        /// <param name="origin">where it happen exactly, the method/function the message was logged in </param>
        /// <param name="filePath"> the codd filename the message was logged from </param>
        /// <param name="lineNumber">the line number filename the message was logged from </param>  
        /// <param name="[CallerMemberName]">This when the value comes it call the member name</param>
        public void Log(
            string message,
            LogLevel level = LogLevel.Informative, 
            [CallerMemberName]string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            //check if we should  not log the message as level is too low..
            if ((int)level < (int)LogOutputLevel)
                return;
            //If the user want to know where the log originated from
            if (IncludeLogOriginDetails)
                message = $"[{Path.GetFileName(filePath)} >{origin} > Line{lineNumber}]{System.Environment.NewLine}{message} ";

            //Log for all loggers
            mLoggers.ForEach(logger => logger.Log(message, level));

            //inform listeners
            NewLog.Invoke((message, level));
        }
        #endregion
    }
       
}
