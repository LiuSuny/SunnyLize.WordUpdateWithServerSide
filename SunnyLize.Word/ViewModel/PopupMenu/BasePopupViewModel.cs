

using SunnyLize.Word.Core;

namespace SunnyLize.Word
{
    /// <summary>
    /// View model for any popup menu
    /// </summary>
    public class BasePopupViewModel : BaseViewModel
    {

        #region Public properties 

        /// <summary>
        /// Background color of the bubble for ARGB value
        /// </summary>
        public string BubbleBackground { get; set; }

       
        /// <summary>
        /// The alignment of the bubble arrow
        /// </summary>
        public ElementHorizontalAlignment ArrowAlignment { get; set; }

        /// <summary>
        /// The content inside the view model
        /// </summary>
        public BaseViewModel Content { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Default ctor
        /// </summary>
        public BasePopupViewModel()
        {
            BubbleBackground = "ffffff";
            ArrowAlignment = ElementHorizontalAlignment.Left;

        }
        #endregion

    }
}
