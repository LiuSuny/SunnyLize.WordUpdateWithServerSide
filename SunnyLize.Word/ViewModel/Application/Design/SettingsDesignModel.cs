

using System;
using System.Xml.Linq;

namespace SunnyLize.Word
{
    /// <summary>
    /// the design-time data for <see cref="SettingsViewModel"/>
    /// </summary>
    public class SettingsDesignModel : SettingsViewModel
    {
        #region Singleton - when you get single instance to an object

        /// <summary>
        /// Single instane of a design model
        /// </summary>
        public static SettingsDesignModel Instance => new SettingsDesignModel();

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public SettingsDesignModel()
        {
            //Todo:return back later on with sqlite
            Name = new TextEntryViewModel { Label = "Name", OriginalText = "Luke Rowland" };
            Username = new TextEntryViewModel { Label = "Username", OriginalText = "Luke" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "*******" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "johndoe@gmail.com" };
        }

        #endregion
    }
}
