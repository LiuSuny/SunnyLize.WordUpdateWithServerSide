

using SunnyLize.Word.Core;
using System.Collections.Generic;

namespace SunnyLize.Word
{
    public class ChatAttachmentPopupMenuViewModel :BasePopupViewModel
    {
        
        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public ChatAttachmentPopupMenuViewModel()
        {
           Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>(new[]
                {
                     new MenuItemViewModel{Text="Attached file....", Type = MenuItemType.Header },
                     new MenuItemViewModel {Text= "From Computer", Icon=IconType.File},
                     new MenuItemViewModel {Text= "From picture", Icon=IconType.Picture},
                })
            };
        }
        #endregion
    }
}
