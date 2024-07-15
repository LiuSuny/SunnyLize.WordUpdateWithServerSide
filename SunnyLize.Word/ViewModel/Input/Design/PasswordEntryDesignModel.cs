

namespace SunnyLize.Word
{
    /// <summary>
    /// The design-time data for a <see cref=" PasswordEntryViewModel"/>
    /// </summary>
    public class PasswordEntryDesignModel : PasswordEntryViewModel
    {
        #region Singleton
        public static PasswordEntryDesignModel Instance = new PasswordEntryDesignModel();

        #endregion

        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public PasswordEntryDesignModel()
        {
            Label = "Name";
            FakePassword = "********";
        } 
        #endregion

    }
}
