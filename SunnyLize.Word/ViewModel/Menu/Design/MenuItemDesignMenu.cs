
using SunnyLize.Word.Core;

namespace SunnyLize.Word
{
    /// <summary>
    /// Design time data for <see cref=" MenuItemViewModel"/>
    /// </summary>
    public class MenuItemDesignMenu : MenuItemViewModel
    {

        #region Singleton

        public static MenuItemDesignMenu Instance => new MenuItemDesignMenu();
        #endregion

        #region Constructor
        /// <summary>
        /// Defualt constructor
        /// </summary>
        public MenuItemDesignMenu()
        {
            Text = "Hello Wicked World";
            Icon = IconType.File;
        } 
        #endregion
    }
}
