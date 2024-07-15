using System.Threading.Tasks;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// Handles read/writing and querying the file system
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        /// Write the text to a specified file
        /// </summary>
        /// <param name="text">the text to write</param>
        /// <param name="path">the path to the file to write to</param>
        /// <param name="append">if this true then write the text to the end of the file, otherwise 
        /// override any existing file </param>
        /// <returns></returns>
        Task WriteAllTextToFileAsync(string text, string path, bool append = false);

        /// <summary>
        /// Normailizing a path based on the current operating system
        /// </summary>
        /// <param name="path">the path to normalize</param>
        /// <returns></returns>
        string NormalizePath(string path);


        /// <summary>
        /// Resolve any relative element of path to absolute
        /// </summary>
        /// <param name="path">the path to resolve</param>
        /// <returns></returns>
        string ResolvePath(string path);
    }
}
