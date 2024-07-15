

using System.Collections.Generic;


namespace SunnyLize.Word
{
    /// <summary>
    /// A view model for the  overview chat list 
    /// </summary>
    public class ChatList1ViewModel:  BaseViewModel
    {
        /// <summary>
        /// The chat list items for the list
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }

        
    }
}
