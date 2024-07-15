

using System.Collections.Generic;

namespace SunnyLize.Word
{
    /// <summary>
    /// the design-time data for <see cref="ChatAttachmentPopupMenuViewModel"/>
    /// </summary>
    public class ChatAttachmentPopupMenuDesignModel : ChatAttachmentPopupMenuViewModel
    {
        #region Singleton - when you get single instance to an object

        /// <summary>
        /// Single instane of a design model
        /// </summary>
        //public static ChatListItemDesignModel Instance { get { return new ChatListItemDesignModel();  } } //old way of returning object it also work using lambda link expression
        public static ChatAttachmentPopupMenuDesignModel Instance => new ChatAttachmentPopupMenuDesignModel();

        #endregion

        #region Constructor
        /// <summary>
        /// defualt ctor
        /// </summary>
        public ChatAttachmentPopupMenuDesignModel()
        {

        } 
        #endregion
    }
}
