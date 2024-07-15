

using System;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// Log to a specific file
    /// </summary>
    public class FileLogger : ILogger
    {
        #region Public members
        /// <summary>
        /// the path to write log file to
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// if true log the current time with eac message
        /// </summary>
        public bool LogTime { get; set; } = true;
        #endregion

        #region Constructor
        /// <summary>
        /// default ctor
        /// </summary>
        /// <param name="filePath">the path to log to</param>
        public FileLogger(string filePath)
        {
            //set the file path property
            FilePath = filePath;
        }
        #endregion



        #region Logger Method
        public void Log(string message, LogLevel level)
        {
            //Get the current time
            var CurrentTime = DateTimeOffset.Now.ToString("yyyy-MM-dd hh:mm:ss");
            
            //Prepend time to log if desire 
            var timeLogString = LogTime ? $"[{CurrentTime}]" : "";

            //write the message to log file
            CoreDI.FileManager.WriteAllTextToFileAsync($"{timeLogString}{message}{Environment.NewLine}",
                FilePath, append: true);
        } 
        #endregion
    }
}
