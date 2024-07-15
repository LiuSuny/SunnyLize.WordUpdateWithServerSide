

namespace SunnyLize.Word
{
    /// <summary>
    /// the design-time data for <see cref="ChatListItemViewModel"/>
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        #region Singleton - when you get single instance to an object
        
        /// <summary>
        /// Single instane of a design model
        /// </summary>
        //public static ChatListItemDesignModel Instance { get { return new ChatListItemDesignModel();  } } //old way of returning object it also work using lambda link expression
        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel(); 

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Message = "This new chat app is awesome! I bet it will be fast too";
            ProfilePictureRGB = "3099c5";
        }

        #endregion
    }
}
