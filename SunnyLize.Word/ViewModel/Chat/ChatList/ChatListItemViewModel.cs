

using SunnyLize.Word.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static SunnyLize.Word.DI;

namespace SunnyLize.Word
{
   
    /// <summary>
    /// A view model for each chat list item in the overview chat list
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {

        #region Public Properties
        /// <summary>
        /// The display name of the chat list
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The latest message from the chat
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The initials to show the picture profile background
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// this is the RGB values (in hex) for the background color of the profile picture
        /// for example FF00FF for Red and blue mixed
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// True if they are unread message in this chat
        /// </summary>
        public bool NewContentAvailable { get; set; }

        /// <summary>
        /// True if the item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }
        
        #endregion

        #region Public Command
        /// <summary>
        /// Open current message thread
        /// </summary>
        public ICommand OpenMessageCommand { get; set; }

        // public ICommand CloseMessageCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// default ctor
        /// </summary>
        public ChatListItemViewModel()
        {
            //Create a command
            OpenMessageCommand = new RelayCommand(OpenMessage);
        }
        #endregion


        #region Command Method
         
        public void OpenMessage ()
        {

            if (Name == "Jesse")
            {
                ViewModelApplication.GoToPage(ApplicationPage.Login, new LoginViewModel
                {
                    Email = "Jesse@HelloWorld.com"


                });

                return;
            }
            ViewModelApplication.GoToPage(ApplicationPage.Chat, new ChatMessageListViewModel
            {
                DisplayTitle = "Parnell Me",

                Items = new ObservableCollection<ChatMessageListItemViewModel>
                {
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Luke",
                        SentByMe = true,

                    },

                     new ChatMessageListItemViewModel
                    {
                        Message = "A recieve message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Parnell",
                        SentByMe = false,

                    },

                      new ChatMessageListItemViewModel
                    {
                        Message = "A recieve message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Parnell",
                        SentByMe = false,

                    },

                       new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Luke",
                        SentByMe = true,

                    },

                     new ChatMessageListItemViewModel
                    {
                        Message = "A recieve message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Parnell",
                        SentByMe = false,

                    },

                      new ChatMessageListItemViewModel
                    {
                        Message = "A recieve message",
                        ImageAttachment = new ChatMessageListItemImageAttachmentViewModel
                        {
                          ThumbnailUrl = "http//anywhere"
                        },
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Parnell",
                        SentByMe = false,

                    },
                }
            });
        }
        #endregion
    }
}
