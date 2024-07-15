
namespace SunnyLize.Word
{
    /// <summary>
    /// Details for a message box dialog
    /// </summary>
    public class MessageBoxDialogDesignModel : MessageBoxDialogViewModel
    {
        #region Signleton
        /// <summary>
        /// way to call our design when binding
        /// </summary>
        public static MessageBoxDialogDesignModel Instance => new MessageBoxDialogDesignModel();

        #endregion

        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public MessageBoxDialogDesignModel()
        {
            OkText = "Ok";
            Message = "Design time messages are fun! :)";
        }
        #endregion
    }
}
