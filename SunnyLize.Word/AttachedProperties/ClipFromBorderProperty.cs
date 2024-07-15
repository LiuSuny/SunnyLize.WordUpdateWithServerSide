

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SunnyLize.Word
{

    /// <summary>
    /// The ClipFromBorderProperty attached property for creating a clipping region
    /// from the <see cref="Border"/> <see cref="CornerRadius"/>
    /// </summary>
    public class ClipFromBorderProperty : BaseAttachedProperty<ClipFromBorderProperty, bool/*what type that attached property is*/>
    {

        #region Private Members
        /// <summary>
        /// Called when the parent border first loaded
        /// </summary>
        private RoutedEventHandler mBorder_Loaded;

        /// <summary>
        /// Called when the parent border size change
        /// </summary>
        private SizeChangedEventHandler mBorder_SizeChanged; 
        #endregion
        public override void OnvalueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //First we need to get self
            var self = (sender as FrameworkElement);

            //check if we have a parent border
            if (!(self.Parent is Border border))

            {
                Debugger.Break();
                return;
            }
            //Set up loaded event 
            mBorder_Loaded = (s1, e1) => Border_OnChange(s1, e1, self);

            //Set up size change event 
            mBorder_SizeChanged = (s1, e1) => Border_OnChange(s1, e1, self);

            //if true hoo to event 
            if ((bool)e.NewValue)
            {
                border.Loaded += mBorder_Loaded;
                border.SizeChanged += mBorder_SizeChanged;
            }

            //otherwise unhook
            else
            {
                border.Loaded -= mBorder_Loaded;
                border.SizeChanged -= mBorder_SizeChanged;
            }
          
        }

        /// <summary>
        /// Called when the border is loaded and change size
        /// </summary>
        /// <param name="sender">the border</param>
        /// <param name="e"></param>
        /// <param name="child">child element (ourself)</param>
        private void Border_OnChange(object sender, RoutedEventArgs e, FrameworkElement child)
        {
            //get the border
            var border = (Border)sender;

            //check if we actually have an actual size
            if (border.ActualWidth == 0 && border.ActualHeight == 0)
                return;

            //If we have an actual size then set up a new cliping area
            var rect = new RectangleGeometry();

            //Match the corner radius with the border corner radius
            rect.RadiusX = rect.RadiusY = Math.Max(0, border.CornerRadius.TopLeft-(border.BorderThickness.Left * 0.5));

            //Set rectange size to match the child actual size
            rect.Rect = new Rect(child.RenderSize);

            //Assign clipping area to the child
            child.Clip = rect;
        }
    }
}
