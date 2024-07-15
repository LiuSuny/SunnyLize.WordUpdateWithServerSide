

using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using SunnyLize.Word.Core;
namespace SunnyLize.Word
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    [ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #region Command Helpers
        /// <summary>
        /// Runs a command if the updating flag is not set
        /// if the flag is true (indicating the function is already running) then the action is not true
        /// if the flag is false(indicating no run function)then the action is run.
        /// Once the action is finsihed if it was run, then the flag is reset to false
        /// </summary>
        /// <param name="updatingflag">the boolean property flag which define if the command is already running</param>
        /// <param name="action">The action to run if the command is not ready running</param>
        /// <returns></returns>
        protected async Task RunCommandAsync(Expression<Func<bool>> updatingflag, Func<Task> action)
        {
            //Checking if the flag property is true (meaning the function is already running)
            if (updatingflag.GetPropertyValue())
                return;

            //Set the property flag to true to indicate we are running
            updatingflag.SetPropertyValue(true);

            try
            {
                //Run the task in action
                await action();
            }
            finally
            {
                //set the property flag back to false now it's finsihed
                updatingflag.SetPropertyValue(false);
            }
        }
        
        private class ImplementPropertyChangedAttribute : Attribute
        {
        }

        #endregion
    }
}
