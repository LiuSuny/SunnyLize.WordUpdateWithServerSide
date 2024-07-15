

using System.Threading.Tasks;

namespace SunnyLize.Word
{
    /// <summary>
    /// The UI manager that handles any UI in the application
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// Displaying a simple message box to the user
        /// Task is use because we need to await when the task is close 
        /// </summary>
        /// <param name="viewModel">View model</param>
        /// <returns></returns>
        Task ShowMessage(MessageBoxDialogViewModel viewModel);

    }
}
