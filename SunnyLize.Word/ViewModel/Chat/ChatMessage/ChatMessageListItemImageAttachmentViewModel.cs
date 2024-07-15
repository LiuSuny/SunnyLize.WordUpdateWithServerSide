

using System;
using System.Threading.Tasks;

namespace SunnyLize.Word
{

    /// <summary>
    /// A view model for each chat message thread item's attachment 
    /// (in this case Image) in a chat thread
    /// </summary>
    public class ChatMessageListItemImageAttachmentViewModel :BaseViewModel
    {

        #region Private Members
       /// <summary>
       /// the thumbnail Url of this attachment
       /// </summary>
        private string mThumbnailUrl;

        #endregion
        /// <summary>
        /// the title of this image file
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The original file name of the attachment
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// the file size in bytes of this attachment
        /// </summary>
        public long FileSize { get; set; }

        /// <summary>
        /// the thumbnail Url of this attachment
        /// </summary>
        public string ThumbnailUrl
        {
            get => mThumbnailUrl;
            set
            {
                //if the value is the same we do nothing
                if (value == mThumbnailUrl)
                    return;

                //however if the value change then we update the value
                mThumbnailUrl = value;

                //TODO: download image from weblink or site 
                //      save file to local/storage cache
                //      set the localfilepath value
                //
                Task.Delay(2000).ContinueWith(t =>
                //For now let set the file path directly
                LocalFilePath = "/Images/Samples/ParisPix.jpg");

            }
        }

        /// <summary>
        /// This is the local file path on these machine to download thumbnail
        /// </summary>
        public string LocalFilePath { get; set; }

        /// <summary>
        /// Indicate if our image has loaded
        /// </summary>
        public bool ImageLoad => LocalFilePath != null;
    }
}
