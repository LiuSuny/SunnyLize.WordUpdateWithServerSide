

using System;
using System.Windows;
using System.Windows.Controls;

namespace SunnyLize.Word
{ 

    /// <summary>
    /// Match the label width of all text entry control inside the panel
    /// </summary>
    public class TextEntryWidthMatcherProperty : BaseAttachedProperty<TextEntryWidthMatcherProperty  /*our source*/, bool/*what type that attached property is*/>
    {
        public override void OnvalueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //First we need to get the panel( typically Grid of some sort)
            var panel = (sender as Panel);

            //call the SetWidths initially(this also help design time to work)
            SetWidths(panel);

            RoutedEventHandler onLoaded = null;
            //Wait for panel to load 
            onLoaded = (ss, ee) =>
            {
                //unHooked to loaded event so we don't fire again
                panel.Loaded -= onLoaded;

                //Set widths
                SetWidths(panel);

                //loop each child 
                foreach (var child in panel.Children)
                {
                    //Igonre any non-text entry control
                    if (!(child is TextEntryControl) && !(child is PasswordEntryControl))
                        continue;
                   
                    // Get the label from the text entry or password entry
                    var label = child is TextEntryControl ? (child as TextEntryControl).Label : (child as PasswordEntryControl).Label;
                    
                    //if the size of control changes save and adjust to new entry size
                    label.SizeChanged += (sss, eee) =>
                    {
                        //update the width size
                        SetWidths(panel);
                    };


                    ////checking if our label actual adjust when change are made 
                    //control.Label.LayoutUpdated += (sss, eee) =>
                    //{
                  
                    //    //update the width size
                    //    SetWidths(panel);
                    //};
                }
            };
            //Hooked to loaded event
            panel.Loaded += onLoaded;

        }

        /// <summary>
        /// Update all child text entry controls so their width 
        /// match the largest width of the group
        /// <param name="panel">the panel that contain the entry controls<param/>
        /// </summary>
        private void SetWidths(Panel panel)
        {
            //keep track of the maximum width
            var maxSize = 0d;

            //For each child...
            foreach(var child in panel.Children)
            {
                
                // Ignore any non-text entry controls
                if (!(child is TextEntryControl) && !(child is PasswordEntryControl))
                    continue;

                var label = child is TextEntryControl ? (child as TextEntryControl).Label : (child as PasswordEntryControl).Label;

               
                // Find if this value is larger than the other controls
                maxSize = Math.Max(maxSize, label.RenderSize.Width + label.Margin.Left + label.Margin.Right);

            }

            //create a grid length converter
            var gridLength = (GridLength)new GridLengthConverter().ConvertFromString(maxSize.ToString());
            //For each child...
            foreach (var child in panel.Children)
            {
                //Igonre any non-text entry control
                if (child is TextEntryControl text)
                    //set each control labelwidth value to the max size
                    text.LabelWidth = gridLength;

                //Set each controls labelWidth value to the max size(this help intense of typing manually in section local textentrycontrol inside settings control               
                if (child is PasswordEntryControl pass)
                    pass.LabelWidth = gridLength;

            }
        }
    }
}
