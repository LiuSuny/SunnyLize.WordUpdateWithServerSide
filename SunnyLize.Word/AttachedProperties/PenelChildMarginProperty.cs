

using System.Windows;
using System.Windows.Controls;

namespace SunnyLize.Word
{ 

    /// <summary>
    /// The NoFrameHistory attached property for creating a<see cref="Panel"/> that never shows navigation
    /// And keep the navigation history empty
    /// </summary>
    public class PenelChildMarginProperty : BaseAttachedProperty<PenelChildMarginProperty /*our source*/, string/*what type that attached property is*/>
    {
        public override void OnvalueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //First we need to get the panel( typically Grid of some sort)
            var penal = (sender as Panel);

            //Wait for panel to load 
            penal.Loaded += (ss, ee) =>
            {
                //loop each child 
                foreach (var child in penal.Children)
                {
                    //set it to margin to given value
                    (child as FrameworkElement).Margin = (Thickness)(new ThicknessConverter().ConvertFromString(e.NewValue as string));


                }
            };

        }
    }
}
