
namespace SunnyLize.Word
{
    /// <summary>
    /// Details for a message box dialog
    /// </summary>
    public class MessageBoxDialogViewModel : BaseDialogViewModel
    {
        
        /// <summary>
        /// The message display
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// the text for ok button
        /// </summary>
        public string OkText { get; set; } = "Ok";
    }
}
