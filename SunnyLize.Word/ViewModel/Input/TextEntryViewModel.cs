

using System;
using System.Windows.Input;

namespace SunnyLize.Word
{
    /// <summary>
    /// view model for any text entry to edit a string value
    /// </summary>
    public class TextEntryViewModel : BaseViewModel
    {
        #region Public Property

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Current save value (meaning the orinal text which is inside our label or textbox)
        /// </summary>
        public string OriginalText { get; set; }

        /// <summary>
        /// the current non-commited text
        /// </summary>
        public string EditedText { get; set; }

        /// <summary>
        /// indicating if the current text is edit mode or not
        /// </summary>
        public bool Editing { get; set; }
        #endregion

        #region Public command
        /// <summary>
        /// put the control into an edit mode
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// Ability to cancel out of editing mode
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Commit the edits and save the value
        /// as well as goes back to non-edit mode
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion


        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public TextEntryViewModel()
        {
            //Create commands
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
        }

        #endregion

        #region Command Methods
        /// <summary>
        /// put the control into edit mode
        /// </summary>
        private void Edit()
        {
            //Powerful feature (^) operator allow edit and exit edit mode
            //Editing ^= true;

            //Seting the edited text to the current value
            EditedText = OriginalText;


            //Go to edit mode
            Editing = true;

        }

        /// <summary>
        /// cancel out edit mode
        /// </summary>
        private void Cancel()
        {
            Editing = false;
        }

        /// <summary>
        /// Commit and save, exit out of edit mode
        /// </summary>
        private void Save()
        {
            //TODO: save the content because no server or backend yet todo later on 
            //Label = EditedText; //playing around
            
            OriginalText = EditedText;

            Editing = false;
        }
        #endregion

    }
}
