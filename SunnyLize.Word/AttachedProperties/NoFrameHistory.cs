

using System.Windows;
using System.Windows.Controls;

namespace SunnyLize.Word
{

    /// <summary>
    /// The NoFrameHistory attached property for creating a<see cref="Frame"/> that never shows navigation
    /// And keep the navigation history empty
    /// </summary>
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory /*our source*/, bool/*what type that attached property is*/>
    {
        public override void OnvalueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //First we need to get the frame
            var frame = (sender as Frame);

            //Hidding the navigation bar
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //Clear history of navigation
            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }
}
