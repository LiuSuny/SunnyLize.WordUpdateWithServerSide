

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static SunnyLize.Word.Core.CoreDI;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// Handles read/writing and querying the file system
    /// </summary>
    public class BaseFileManager: IFileManager
    {
        /// <summary>
        /// Write the text to a specified file
        /// </summary>
        /// <param name="text">the text to write</param>
        /// <param name="path">the path to the file to write to</param>
        /// <param name="append">if this true then write the text to the end of the file, otherwise 
        /// override any existing file </param>
        /// <returns></returns>
        public async Task WriteAllTextToFileAsync(string text, string path, bool append = false)
        {
            //TODO: Add exception catching

            //Normalize path
            path = NormalizePath(path);

            //Resolve two obsolute path
            path = ResolvePath(path);

            //Lock the task
            await AsyncAwaiter.AwaitAsync(nameof(BaseFileManager) + path, async() =>
            {
                //TODO: Add IOCContainer.Task.Run that log to logger on failure 
                //Run the synchronous file as new task 
                await TaskManager.Run(() =>
                {
                    //Write a log message to file
                    using (var fileStream = (TextWriter)new
                    StreamWriter(File.Open(path, append ? FileMode.Append : FileMode.Create)))
                        fileStream.Write(text);


                   // var fileStream = (TextWriter)new
                   //  StreamWriter(File.Open(path, append ? FileMode.Append : FileMode.Create));
                   //try
                   // {
                   //     fileStream.Write(text);
                   // }
                   // finally 
                   // {
                   //     fileStream.Dispose();
                   // }
                });
            });         
        }

        /// <summary>
        /// Normailizing a path based on the current operating system
        /// </summary>
        /// <param name="path">the path to normalize</param>
        /// <returns></returns>
        public string NormalizePath(string path)
        {
            //if it is on window
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                //Replace any /forward with \\back
                return path?.Replace('/', '\\').Trim();
            //if it on linux/mac
            else
                //replace any \\ with /
                return path?.Replace('\\', '/').Trim();
        }



        /// <summary>
        /// Resolve any relative element of path to absolute
        /// </summary>
        /// <param name="path">the path to resolve</param>
        /// <returns></returns>
        public string ResolvePath(string path)
        {
            //Resolve the path to absolute
            return Path.GetFullPath(path);
        }
    }
}
