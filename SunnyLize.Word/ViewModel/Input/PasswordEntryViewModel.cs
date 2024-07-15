

using System;
using System.Security;
using System.Windows.Input;
using SunnyLize.Word.Core;
using static SunnyLize.Word.DI;

namespace SunnyLize.Word
{
    /// <summary>
    /// view model for any password entry to edit a string value
    /// </summary>
    public class PasswordEntryViewModel : BaseViewModel
    {
        #region Public Property

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// string fake password display
        /// </summary>
        public string FakePassword { get; set; }

        /// <summary>
        ///  current password hint text
        /// </summary>
        public string CurrentPasswordHintText { get; set; }

        /// <summary>
        /// new password hint text
        /// </summary>
        public string NewPasswordHintText { get; set; }

        /// <summary>
        /// confirm password hint text
        /// </summary>
        public string ConfirmPasswordHintText { get; set; }


        /// <summary>
        /// Current save password
        /// </summary>
        public SecureString CurrentPassword { get; set; }

        /// <summary>
        /// the current non-commited edited password
        /// </summary>
        public SecureString NewPassword { get; set; }

        /// <summary>
        /// the current non-commited edited confirm password
        /// </summary>
        public SecureString ConfirmPassword { get; set; }

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
        public PasswordEntryViewModel()
        {
            //Create commands
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);

            //Set default hint
            //TODO: replace with localization text

            CurrentPasswordHintText = "Current Password";
            NewPasswordHintText = "New Password";
            ConfirmPasswordHintText = "Confirm Password";
        }

        #endregion

        #region Command Methods
        /// <summary>
        /// put the control into edit mode
        /// </summary>
        private void Edit()
        {
            //Clear all password
            NewPassword = new SecureString();
            ConfirmPassword = new SecureString();

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

            //Make sure current password is correct
            //TODO: this will come from the real backend store of this users password
            //Or via asking the web server to confirm it
            var storedPassword = "Testing";  //just demo purposes


            //Confirm the current password is a match 
            //NOTE: Typically this isn't done here but it done on the server side


            if (storedPassword != CurrentPassword.UnSecure())
            {
                //just to tell the user 
                UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Wrong password",
                    Message = "Current password is invalid"
                });
                return;
            }

            //Now check that the new and confirm is a match
            if (NewPassword.UnSecure() != ConfirmPassword.UnSecure())
            {
                //just to tell the user 
                UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password mismatch",
                    Message = "The new and confirm password do not match"
                });
                return;
            }


            //Checking to make sure our password is not zero length and that we actually have a password 
            if (NewPassword.UnSecure().Length == 0 )
            {
                //just to tell the user 
                UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password to short",
                    Message = "You must enter a password!"
                });
                return;
            }


            //Seting the edited password to the current value password
            CurrentPassword = new SecureString();
            foreach (var c in NewPassword.UnSecure().ToCharArray())
                CurrentPassword.AppendChar(c);


            ////if at all the above does work we try to unsecure the password and check to see what we got
            //var actualCurrentPassword = CurrentPassword.UnSecure();
            //var actualPassword = NewPassword.UnSecure();
            //var actualConfirmPassword = ConfirmPassword.UnSecure();


            //TODO: save the content because no server or backend yet todo later on 
            //Label = EditedText; //playing around

            // OriginalText = EditedText;

            Editing = false;
        }
        #endregion

    }
}
