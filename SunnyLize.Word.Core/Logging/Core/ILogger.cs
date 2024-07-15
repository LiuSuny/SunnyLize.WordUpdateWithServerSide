

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// A logger that will handle all file log message from <see cref="ILogFactory"/>
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Handle the logged message being passed in
        /// </summary>
        /// <param name="message">the message being log</param>
        /// <param name="level">the level of the message</param>
        void Log(string message, LogLevel level);
    }
}
