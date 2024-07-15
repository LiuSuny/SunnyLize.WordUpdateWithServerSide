using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace SunnyLize.Word
{
    /// <summary>
    /// Focus (keyboard focus) this element is onload 
    /// </summary>
    public class IsFocusProperty : BaseAttachedProperty<IsFocusProperty, bool>
    {
        /// <summary>
        /// This class basically allow keyboard focus on whatever object we attach it in our project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void OnvalueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //if we don't have a control return nothing
            if (!(sender is Control control))
                return;

            //if we do have a control then we focus this control once it is loaded ---Focus() set keyboard focus on visual
            control.Loaded += (s, se) => control.Focus();
        }

       
    }



    /// <summary>
    /// Focus (keyboard focus) this element is true 
    /// </summary>
    public class FocusProperty : BaseAttachedProperty<FocusProperty, bool>
    {
        /// <summary>
        /// This class basically allow keyboard focus on whatever object we attach it in our project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void OnvalueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //if we don't have a control return nothing
            if (!(sender is Control control))
                return;

            //If this boolean new value is true
            if((bool)e.NewValue)
            //then focus on this control
            control.Focus();
        }


    }



    /// <summary>
    /// Focus (keyboard focus) and select all this element if true 
    /// </summary>
    public class FocusAndSelectProperty : BaseAttachedProperty<FocusAndSelectProperty, bool>
    {
        /// <summary>
        /// This class basically allow keyboard focus on whatever object we attach it in our project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void OnvalueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //if we don't have a control return nothing           
            if (sender is TextBoxBase control)
            {

                //If this boolean new value is true
                if ((bool)e.NewValue)
                {
                    //then focus on this control
                    control.Focus();

                    //Select Text
                    control.SelectAll();
                }
            }

            //if we don't have a control return nothing           
            if ((sender is PasswordBox password))
            {

                //If this boolean new value is true
                if ((bool)e.NewValue)
                {
                    //then focus on this control
                    password.Focus();

                    //Select Text
                    password.SelectAll();
                }
            }
        }


    }



}
