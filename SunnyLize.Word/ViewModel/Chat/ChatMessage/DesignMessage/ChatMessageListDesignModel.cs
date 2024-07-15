

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SunnyLize.Word
{
    /// <summary>
    /// the design-time data for <see cref="ChatMessageListViewModel"/>
    /// </summary>
    public class ChatMessageListDesignModel : ChatMessageListViewModel
    {
        #region Singleton - when you get single instance to an object

        /// <summary>
        /// Single instane of a design model
        /// </summary>
        //public static ChatListItemDesignModel Instance { get { return new ChatListItemDesignModel();  } } //old way of returning object it also work using lambda link expression
        public static ChatMessageListDesignModel Instance => new ChatMessageListDesignModel();

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatMessageListDesignModel()
        {
            DisplayTitle = "Parnell";
            Items = new ObservableCollection<ChatMessageListItemViewModel>
            {              

                 new ChatMessageListItemViewModel
               {
                  SenderName = "Parnell",
                   Initials = "PL",
                   Message = "I'm about to wipe out the old server, we need to update the old server to window 2024",
                  ProfilePictureRGB = "00d405",
                  MessageSentTime = DateTimeOffset.UtcNow,
                    
                  SentByMe = false
               },

                 new ChatMessageListItemViewModel
               {
                   SenderName = "Luke",
                   Initials = "LM",
                   Message = "Let me know when you manage to spin up the new 2022 server",
                  ProfilePictureRGB = "3099c5",
                   MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                  MessageSentTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(1.3)), //this will just set a ramdom time
                  SentByMe = true
               },
                new ChatMessageListItemViewModel
               {
                  SenderName = "Jesse",
                   Initials = "JA",
                   Message = "The new server is up go to 192.168.1.1.\r\nusername  is admin, password passw0rd",
                  ProfilePictureRGB = "fe4503",
                  MessageSentTime = DateTimeOffset.UtcNow,
                
                  SentByMe = false

               },

            };
        }

        #endregion
    }
}
