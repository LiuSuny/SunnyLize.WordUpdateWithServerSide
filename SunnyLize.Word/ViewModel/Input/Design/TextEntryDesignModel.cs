

namespace SunnyLize.Word
{
    /// <summary>
    /// The design-time data for a <see cref="TextEntryViewModel"/>
    /// </summary>
    public class TextEntryDesignModel : TextEntryViewModel
    {
        #region Singleton
        public static TextEntryDesignModel Instance = new TextEntryDesignModel();

        #endregion

        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public TextEntryDesignModel()
        {
            Label = "Name";
            OriginalText = "Luke Rowland";
            EditedText = "Editing :)";
           
        } 
        #endregion

    }
}
