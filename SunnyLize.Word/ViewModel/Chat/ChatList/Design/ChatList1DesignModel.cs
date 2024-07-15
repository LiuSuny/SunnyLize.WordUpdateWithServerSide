

using System.Collections.Generic;
using System.Xml.Linq;

namespace SunnyLize.Word
{
    /// <summary>
    /// the design-time data for <see cref="ChatList1ViewModel"/>
    /// </summary>
    public class ChatList1DesignModel : ChatList1ViewModel
    {
        #region Singleton - when you get single instance to an object

        /// <summary>
        /// Singleto instane of a design model
        /// </summary>
        //public static ChatListItemDesignModel Instance { get { return new ChatListItemDesignModel();  } } //old way of returning object it also work using lambda link expression
        public static ChatList1DesignModel Instance => new ChatList1DesignModel();

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatList1DesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
               new ChatListItemViewModel
               {
                   Name = "Luke",
                   Initials = "LM",
                   Message = "This new chat app is awesome! I bet it will be fast too",
                  ProfilePictureRGB = "3099c5",
                   NewContentAvailable= true
               },
                new ChatListItemViewModel
               {
                   Name = "Jesse",
                   Initials = "JA",
                   Message = "Hey dude, here are the new icons",
                  ProfilePictureRGB = "fe4503"
               },
                 new ChatListItemViewModel
               {
                   Name = "Parnel",
                   Initials = "PL",
                   Message = "The new server is up, go to 192.168.1.1",
                  ProfilePictureRGB = "00d405",
                   IsSelected= true
               },

                 new ChatListItemViewModel
               {
                   Name = "Luke",
                   Initials = "LM",
                   Message = "This new chat app is awesome! I bet it will be fast too",
                  ProfilePictureRGB = "3099c5"
               },
                new ChatListItemViewModel
               {
                   Name = "Jesse",
                   Initials = "JA",
                   Message = "Hey dude, here are the new icons",
                  ProfilePictureRGB = "fe4503"
                 
               },
                 new ChatListItemViewModel
               {
                   Name = "Parnel",
                   Initials = "PL",
                   Message = "The new server is up, go to 192.168.1.1",
                  ProfilePictureRGB = "00d405"                
               },

                  new ChatListItemViewModel
               {
                   Name = "Luke",
                   Initials = "LM",
                   Message = "This new chat app is awesome! I bet it will be fast too",
                  ProfilePictureRGB = "3099c5",
                   
               },

                   new ChatListItemViewModel
               {
                   Name = "Jesse",
                   Initials = "JA",
                   Message = "Hey dude, here are the new icons",
                  ProfilePictureRGB = "fe4503"
               },
                     new ChatListItemViewModel
               {
                   Name = "Parnel",
                   Initials = "PL",
                   Message = "The new server is up, go to 192.168.1.1",
                  ProfilePictureRGB = "00d405"
               },
            };
        }

            #endregion
    }
}

       


