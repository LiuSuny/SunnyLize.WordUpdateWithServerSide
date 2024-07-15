

using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace SunnyLize.Word
{
    /// <summary>
    /// A base view model for dialog that fires Property Changed events as needed
    /// </summary>
    public class BaseDialogViewModel : BaseViewModel
    {
        /// <summary>
        /// title of the message dialog
        /// </summary>
        public string Title { get; set; }

    }
}
