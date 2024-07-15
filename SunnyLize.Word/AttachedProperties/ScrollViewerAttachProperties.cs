

using System;
using System.Windows;
using System.Windows.Controls;

namespace SunnyLize.Word
{

    /// <summary>
    /// scroll content to bottom when it changes
    /// </summary>
    public class ScrollToBottomOnLoadProperty : BaseAttachedProperty<ScrollToBottomOnLoadProperty, bool>
    {
        public override void OnvalueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //if we don't have control return nothing
            if (!(sender is ScrollViewer control))
                return;

            //scroll content to bottom when it change
            control.DataContextChanged -= Control_DataContextChanged;           
            control.DataContextChanged += Control_DataContextChanged;

            
        }

        private void Control_DataContextChanged(object sender,
            DependencyPropertyChangedEventArgs e) => (sender as ScrollViewer).ScrollToBottom();  //Scroll to bottom
        
          
            
        
    }

    /// <summary>
    /// Automatically keep the scroll at the bottom of the screen when are already close to the bottom
    /// </summary>
    public class AutoScrollToBottomProperty : BaseAttachedProperty<AutoScrollToBottomProperty, bool>
    {
        public override void OnvalueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //if we don't have control return nothing
            if (!(sender is ScrollViewer control))
                return;

            //scroll content to bottom when it change
            control.ScrollChanged -= Control_ScrollChanged;
            control.ScrollChanged += Control_ScrollChanged;


        }

        private void Control_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scroll = sender as ScrollViewer;
            //if we are close enough to bottom
            if (scroll.ScrollableHeight - scroll.VerticalOffset < 20)
                //then scroll to the bottom
                scroll.ScrollToEnd();

        }

        




    }
}
