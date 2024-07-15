
using SunnyLize.Word.Core;
using System.Collections.Generic;

namespace SunnyLize.Word
{
    public class MenuDesignModel : MenuViewModel
    {
        #region Singleton

        public static MenuDesignModel Instance => new MenuDesignModel();
        #endregion


        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public MenuDesignModel()
        {
            Items = new List< MenuItemViewModel> (new[]
            {
                  new MenuItemViewModel {Type = MenuItemType.Header,Text="Design time header....."},
                  new MenuItemViewModel {Text= "Menu item 1", Icon=IconType.File},
                  new MenuItemViewModel {Text= "Menu item 2", Icon=IconType.Picture},

          });
        } 
        #endregion
    }
}
