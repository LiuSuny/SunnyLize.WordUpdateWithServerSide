using SunnyLize.Word.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SunnyLize.Word
{
    /// <summary>
    /// A view model for chat message thread list 
    /// </summary>
    public class ChatMessageListViewModel :BaseViewModel
    {
        #region Protected Members
        /// <summary>
        /// Last search text in this list
        /// </summary>
        protected string mLastSearchText;

        /// <summary>
        /// The text to search for in search command
        /// </summary>
        protected string mSearchText;

        /// <summary>
        /// The chat message list items for the list
        /// </summary>
        protected ObservableCollection<ChatMessageListItemViewModel> mItems;

        /// <summary>
        /// A flag that indicate if a search dialog is open
        /// </summary>
        protected bool mSearchIsOpen;
        #endregion


        #region Public Property
        /// <summary>
        /// The chat message list items for the list
        /// NOTE: we are not calling Items.Add to add a message to this list
        /// as it will make the filtered out of async
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> Items 
        {   get => mItems; 
            set
            {
                //make sure list has 
                if (mItems == value)
                    return;

                //Otherwise update the value
                mItems = value;

                //we try this but got reference 
                //FilteredItems = mItems;

                //update the filteres list to match
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(mItems);

                
            }
        }

        /// <summary>
        /// The chat message list items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> FilteredItems { get; set; }

        /// <summary>
        /// Title of this chat list 
        /// </summary>
        public string DisplayTitle { get; set; }

        /// <summary>
        /// the text to search for when we do a search
        /// </summary>
        public string SearchText
        {
            get => mSearchText;
            set
            {
                //check value is different
                if (mSearchText == value)
                    return;

                //otherwise update
                mSearchText = value;

                //if the search text is empty...
                if (string.IsNullOrEmpty(mSearchText))
                    //search to restore messages
                    Search();
            }
        }

        /// <summary>
        /// Flag indicating that the search dialog is open
        /// </summary>
        public bool SearchIsOpen
        {
            get => mSearchIsOpen;
            set
            {
                //Check again
                if (mSearchIsOpen == value)
                    return;
                //other update 
                mSearchIsOpen = value;

                //if the dialog closes 
                if (!mSearchIsOpen)
                    //clear the search text
                    SearchText = string.Empty;
            }
        }
        /// <summary>
        /// true to show the attached menu, false to hide it
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }

        /// <summary>
        /// True if any popup menu is visible
        /// </summary>
        public bool AnyPopupVisible => AttachmentMenuVisible; //pratically the same

        /// <summary>
        /// View model for the attachment menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }


        /// <summary>
        /// The text for the current message been written
        /// </summary>
        public string PendingMessageText { get; set; }
        #endregion

        #region Public Command

        /// <summary>
        /// The command for when the attached button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        /// <summary>
        /// The command for when the area outside of any popup is clicked 
        /// </summary>
        public ICommand PopupClickAwayCommand { get; set; }

        /// <summary>
        /// The command for when user clicked send command
        /// </summary>
        public ICommand SendCommand { get; set; }

        /// <summary>
        /// The command for when user want to search text
        /// </summary>
        public ICommand SearchCommand { get; set; }

        /// <summary>
        /// The command for when user want to open search dialog
        /// </summary>
        public ICommand OpenSearchCommand { get; set; }

        /// <summary>
        /// The command for when user want to close search dialog
        /// </summary>
        public ICommand CloseSearchCommand { get; set; }

        /// <summary>
        /// The command for when user want to clear search text
        /// </summary>
        public ICommand ClearSearchCommand { get; set; }

        #endregion


        #region Constructors

        public ChatMessageListViewModel()
        {
            //We try to create command
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);

            PopupClickAwayCommand = new RelayCommand(PopupClickAway);

            SendCommand = new RelayCommand(Send);
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);

            //Creating default menu
            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }
      
        #endregion

        #region Command method
        /// <summary>
        /// When the attachment button is clicked it show/hidden the attachement popup
        /// </summary>
        public void AttachmentButton()
        {
            //Toggle menu visible --- (^) this operator is boolean which toggle object to true or false
            AttachmentMenuVisible ^= true;
        }

        /// <summary>
        /// When the Pop-up Click Away  area is clicked, hidden any other popups
        /// </summary>
        public void PopupClickAway()
        {
           //Hide attachemnt menu
            AttachmentMenuVisible = false;
        }

        /// <summary>
        /// When the user Click send button message area is clicked
        /// </summary>
        public void Send()
        {


            ////this UI independent as the core has no idea as we can invoke the UI function
            ///* await*/
            //IOCContainer.UI.ShowMessage(new MessageBoxDialogViewModel
            //{
            //    Title = "Send Message",
            //    Message = "Thank you for writing a nice message :)",
            //    OkText = "OK"
            //});

            //var ss = true;

            //Don;t send a blank message
            if (string.IsNullOrEmpty(PendingMessageText))
                return;

            //Ensure lists are not null
            if (Items == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();
            if (FilteredItems == null)
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>();
            //Fake send new message
            var message = (new ChatMessageListItemViewModel
            {
                Initials = "LM",
                Message = PendingMessageText,
                MessageSentTime = DateTime.UtcNow, 
                SentByMe = true,
                SenderName = "John Sunglas",
                NewItem = true,
            }) ;

            //Add message to both lists
            Items.Add(message);
            FilteredItems.Add(message);

            //Clear the pending message text
            PendingMessageText = string.Empty;

        }

        /// <summary>
        /// Searches the current message list and filtered the view
        /// </summary>
        public void Search()
        {
            //Making sure we don't re-search the same text
            if ((string.IsNullOrEmpty(mLastSearchText) && string.IsNullOrEmpty(SearchText)) ||
                    string.Equals(mLastSearchText, SearchText))
                return;
            //if we have no search text, or no items
            if(string.IsNullOrEmpty(SearchText) || Items == null || Items.Count <= 0) //If there is nothing to search
            {
                //then make sure to filtered list the same 
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items);
               
                //set last search text
                mLastSearchText = SearchText;
                
                return;

            }

            //Find all the items that contains a give text
            //TODO: I need to make more efficient search (server side)

            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items.Where(
                item => item.Message.ToLower().Contains(SearchText)));

                //set the last search text
                mLastSearchText = SearchText;


        }

        /// <summary>
        /// Clear the search text
        /// </summary>
        public void ClearSearch()
        {
            //If there is a search text
            if (!string.IsNullOrEmpty(SearchText))
                //clear the text
                SearchText = string.Empty;
            //otherwise
            else
                //Close the search dialog
                SearchIsOpen = false;
        }

        /// <summary>
        /// Open the search dialog
        /// </summary>
        public void OpenSearch() => SearchIsOpen = true;


        /// <summary>
        /// Close the search dialog
        /// </summary>
        public void CloseSearch() => SearchIsOpen = false;
        

       
        #endregion
    }
}
