

using Newtonsoft.Json.Linq;
using SunnyLize.Word.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SunnyLize.Word
{
    /// <summary>
    /// the base class to run any animation method when the boolean is set to true and
    /// a reverse animation is set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> :BaseAttachedProperty<Parent, bool>
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
       
        #region Protected Properties
        /// <summary>
        /// True if this is the very first time the value has been updated
        /// used to make sure we run the logic at least once during first load
        /// </summary>
        //protected bool mFirstFire = true;
        protected Dictionary<WeakReference, bool> mFirstLoadValue = new Dictionary<WeakReference, bool>();
        /// <summary>
        /// the flag indicating if it is the first the property that have  load
        /// </summary>
        protected Dictionary<WeakReference, bool> mAlreadyLoaded = new Dictionary<WeakReference, bool>();
        #endregion

        #region public property

        /// <summary>
        /// the flag indicating if it is the first the property that have  load
        /// </summary>
        //public bool FirstLoad { get; set; } = true;
       
        #endregion
        public override void OnvalueUpdated(DependencyObject sender, object value)
        {
            //try to get the framwork element
            if (!(sender is FrameworkElement element)) return;

            // Try and get the already loaded reference ---added today 28.06
            var mAlreadyLoadedReference = mAlreadyLoaded.FirstOrDefault(f => f.Key.Target == sender);
            //don't fire if the vaue doesn't change and we comparing reason why we cast it directly to boolean else it might fail
            //if ((bool)sender.GetValue(ValueProperty) == (bool)value && !mFirstFire)

            // Try and get the first load reference
            var firstLoadReference = mFirstLoadValue.FirstOrDefault(f => f.Key.Target == sender);

            //if ((bool)sender.GetValue(ValueProperty) == (bool)value && mAlreadyLoaded.ContainsKey(sender))
            if((bool)sender.GetValue(ValueProperty) == (bool)value && mAlreadyLoadedReference.Key != null)
            return; //if the value doesn't change, then do nothing except if it is the first time

            //No longer first load
            // mFirstFire = false;

            //On first load...

            // if (!mAlreadyLoaded.ContainsKey(sender))
            if (mAlreadyLoadedReference.Key == null)
            {

                // Flag that we are in first load but have not finished it
                //mAlreadyLoaded[sender] = false;
                // Create weak reference
                var weakReference = new WeakReference(sender);

                // Flag that we are in first load but have not finished it
                mAlreadyLoaded[weakReference] = false;
                //if we are to animate initially
                //if (!(bool)value) //animate out by default so animate in
                //start off hidded animation untill we decide how to animate                
                element.Visibility = Visibility.Hidden;

                //hooking it to first load on a single file - by creating single self-unhookable event
                //For the element loaded to the event
                //RoutedEventHandler onLoaded = (ss, ee) =>
                // {  
                //     element.Loaded -= onLoaded; //encounter error use of unassign local variable when we try this way
                // };


                //practical we create event allow it to run and load, hook to event and there after unhook itself
                RoutedEventHandler onLoaded = null;   //technically it been assign
                //created an event
                onLoaded = async (ss, ee) =>
                {
                    
                    //Unhooked ourselves
                    element.Loaded -= onLoaded;

                    //Slight delay after load is needed for some element to get laid out
                    //and their width/height are correctly calculated
                    await Task.Delay(5);

                    // Refresh the first load value in case it changed
                    // since the 5ms delay
                    firstLoadReference = mFirstLoadValue.FirstOrDefault(f => f.Key.Target == sender);

                    //We doing the desired animation
                    //DoAnimation(element, (bool)value);
                    //DoAnimation(element, mFirstLoadValue.ContainsKey(sender) ? mFirstLoadValue[sender] : (bool)value, true);

                    DoAnimation(element, firstLoadReference.Key != null ? firstLoadReference.Value : (bool)value, true);
                    //Once we done it no longer in first load
                    //FirstLoad = false;

                    // Flag that we have finished first load
                    mAlreadyLoaded[weakReference] = true;
                };

                //Hook into the loaded event of the element
                element.Loaded += onLoaded;
            }
               // If we have started a first load but not fired the animation yet, update the property
            else if (mAlreadyLoadedReference.Value == false)
                mFirstLoadValue[new WeakReference(sender)] =(bool)value;
            else 
               
                DoAnimation(element, (bool)value, false);

        }

        /// <summary>
        /// the animation method that is fire when the value changes
        /// </summary>
        /// <param name="element">the element</param>
        /// <param name="value">the new value</param>
       
        protected virtual void DoAnimation(FrameworkElement element, bool value, bool firstLoad) { }
    }

    /// <summary>
    /// Fade in an image once the source changes
    /// </summary>
    public class FadeInImageOnLoadProperty :AnimateBaseProperty<FadeInImageOnLoadProperty>
    {
        public override void OnvalueUpdated(DependencyObject sender, object value)
        {
            //make sure we have an image
            if (!(sender is Image image))
                return;

            //if the value pass in is true image then we animate in
            if((bool)value)
                image.TargetUpdated += Image_TargetUpdatedAsync;
            else
                image.TargetUpdated -= Image_TargetUpdatedAsync;
        }

        private async void Image_TargetUpdatedAsync(object sender, System.Windows.Data.DataTransferEventArgs e)
        {

            //Fade in image
            await (sender as Image).FadeInAsync(false);
        }
    }

    /// <summary>
    /// Animate a framework element sliding in from the left show 
    /// and slide out to the left on hide
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
       // protected override async void DoAnimation(FrameworkElement element, bool value) 
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                //Animate in---///FirstLoad ? 0 : 0.3f if it firstload do nothing otherwise animate the same
                //FirstLoad ? 0.3f : 0.3f will allow our both pages to load at the same time
                //await element.SlideAndFadeInAsync(firstLoad ? 0 : 0.3f, keepMargin:false);
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Left, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                //otherwise animate out
                //await element.SlideAndFadeOutToLeft(firstLoad ? 0 : 0.3f, keepMargin:false);
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Left, firstLoad ? 0 : 0.3f, keepMargin: false);

        }
    }

    /// <summary>
    /// Animate a framework element sliding in from the right show 
    /// and slide out to the right on hide
    /// </summary>
    public class AnimateSlideInFromRightProperty : AnimateBaseProperty<AnimateSlideInFromRightProperty>
    {
        // protected override async void DoAnimation(FrameworkElement element, bool value) 
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                //Animate in---///FirstLoad ? 0 : 0.3f if it firstload do nothing otherwise animate the same
                //FirstLoad ? 0.3f : 0.3f will allow our both pages to load at the same time
                //await element.SlideAndFadeInAsync(firstLoad ? 0 : 0.3f, keepMargin:false);
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Right, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                //otherwise animate out
                //await element.SlideAndFadeOutToLeft(firstLoad ? 0 : 0.3f, keepMargin:false);
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Right, firstLoad ? 0 : 0.3f, keepMargin: false);

        }
    }


    /// <summary>
    /// Animate a framework element sliding in from the right show 
    /// and slide out to the right on hide
    /// </summary>
    public class AnimateSlideInFromRightMarginProperty : AnimateBaseProperty<AnimateSlideInFromRightMarginProperty>
    {
        // protected override async void DoAnimation(FrameworkElement element, bool value) 
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                //Animate in---///FirstLoad ? 0 : 0.3f if it firstload do nothing otherwise animate the same
                //FirstLoad ? 0.3f : 0.3f will allow our both pages to load at the same time
                //await element.SlideAndFadeInAsync(firstLoad ? 0 : 0.3f, keepMargin:false);
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Right, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: true);
            else
                //otherwise animate out
                //await element.SlideAndFadeOutToLeft(firstLoad ? 0 : 0.3f, keepMargin:false);
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Right, firstLoad ? 0 : 0.3f, keepMargin: true);

        }
    }


    /// <summary>
    /// Animate a framework element sliding up from the bottom show 
    /// and slide out from the bottom on hide
    /// </summary>
    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        //protected override async void DoAnimation(FrameworkElement element, bool value)
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                //Animate in---///FirstLoad ? 0 : 0.3f if it firstload do nothing otherwise animate the same
                //FirstLoad ? 0.3f : 0.3f will allow our both pages to load at the same time
                //await element.SlideAndFadeInFromBottom(FirstLoad ? 0 : 0.3f, keepMargin: false);
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                //otherwise animate out
                //await element.SlideAndFadeOutToBottom(FirstLoad ? 0 : 0.3f, keepMargin: false);
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Bottom, firstLoad ? 0 : 0.3f, keepMargin: false);

        }
    }


    /// <summary>
    /// Animate a framework element sliding up from the bottom on load 
    /// if the value is true
    /// </summary>
    public class AnimateSlideInFromBottomOnLoadProperty : AnimateBaseProperty<AnimateSlideInFromBottomOnLoadProperty>
    {
        //protected override async void DoAnimation(FrameworkElement element, bool value)
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
           
            await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, !value, !value ? 0 : 0.3f, keepMargin: false);
           
        }
    }

    /// <summary>
    /// Animate a framework element sliding up from the bottom show 
    /// and slide out from the bottom on hide
    /// Note: We are keeping the margin
    /// </summary>
    public class AnimateSlideInFromBottomMarginProperty : AnimateBaseProperty<AnimateSlideInFromBottomMarginProperty>
    {
       // protected override async void DoAnimation(FrameworkElement element, bool value)
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                //Animate in---///FirstLoad ? 0 : 0.3f if it firstload do nothing otherwise animate the same
                //FirstLoad ? 0.3f : 0.3f will allow our both pages to load at the same time
                //await element.SlideAndFadeInFromBottom(FirstLoad ? 0 : 0.3f, keepMargin: true);
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: true);
            else
                //otherwise animate out
                //await element.SlideAndFadeOutToBottom(FirstLoad ? 0 : 0.3f, keepMargin: true);
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Bottom, firstLoad ? 0 : 0.3f, keepMargin: true);

        }
    }

    /// <summary>
    /// Animate a framework element fading in on show 
    /// and fading out on hide
    /// </summary>
    public class AnimateFadeInInProperty : AnimateBaseProperty<AnimateFadeInInProperty>
    {
        //protected override async void DoAnimation(FrameworkElement element, bool value)
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                //Animate in---///FirstLoad ? 0 : 0.3f if it firstload do nothing otherwise animate the same
                //FirstLoad ? 0.3f : 0.3f will allow our both pages to load at the same time
                //await element.FadeInAsync(FirstLoad ? 0 : 0.3f);
                await element.FadeInAsync(firstLoad, firstLoad ? 0 : 0.3f);
            else
                //otherwise animate out
                //await element.FadeOutAsync(FirstLoad ? 0 : 0.3f);
                await element.FadeOutAsync(firstLoad ? 0 : 0.3f);

        }
    }

}
