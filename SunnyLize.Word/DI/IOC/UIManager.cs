

using SunnyLize.Word.Core;
using System.Threading.Tasks;
using System.Windows;

namespace SunnyLize.Word
{
    /// <summary>
    /// Application implementation of <see cref="IUIManager"/>
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    public class UIManager : IUIManager
    {
        /// <summary>
        /// Displaying a simple message box to the user
        /// Task is use because we need to await when the task is close 
        /// </summary>
        /// <param name="viewModel">View model</param>
        /// <returns></returns>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            //TODO:
            return new DialogMessagesBox().ShowDialog(viewModel);

        }
    }
}
