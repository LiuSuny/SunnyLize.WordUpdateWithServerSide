

using System;
using System.Xml.Linq;

namespace SunnyLize.Word
{
    /// <summary>
    /// the design-time data for <see cref="ChatMessageListItemViewModel"/>
    /// </summary>
    public class ChatMessageListItemDesignModel :ChatMessageListItemViewModel 
    {
        #region Singleton - when you get single instance to an object

        /// <summary>
        /// Single instane of a design model
        /// </summary>
        //public static ChatListItemDesignModel Instance { get { return new ChatListItemDesignModel();  } } //old way of returning object it also work using lambda link expression
        public static ChatMessageListItemDesignModel Instance => new ChatMessageListItemDesignModel();

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatMessageListItemDesignModel()
        {
            Initials = "LM";
            SenderName = "Luke";
            Message = "Some view model design time visual text";
            ProfilePictureRGB = "3099c5";
            SentByMe = true;
            MessageSentTime = DateTimeOffset.UtcNow;
            MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3));

                
        }

        #endregion
    }
}
