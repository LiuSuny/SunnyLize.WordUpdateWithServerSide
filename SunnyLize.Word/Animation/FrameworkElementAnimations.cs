using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;
using static SunnyLize.Word.Core.CoreDI;

namespace SunnyLize.Word.Animation
{
    /// <summary>
    /// Help us to animate framework element in specific ways
    /// </summary>
    public static class FrameworkElementAnimations
    {
        #region Slide  in and out 
       
        /// <summary>
        /// Slides an element in from the left
        /// </summary>
        /// <param name="element">element to animate</param>
        /// <param name="seconds">the time the animation will take</param>
        ///  <param name="keepMargin">Whether to keep the element at the same width during the animation</param>
        ///  <param name="width">The animation width  to animate to, if not specified the element width is use</param>
        /// <returns></returns>
       // public static async Task SlideAndFadeInFromLeft(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        public static async Task SlideAndFadeInAsync(this FrameworkElement element, AnimationSlideInDirection direction, bool firstLoad, float seconds = 0.3f, bool keepMargin = true, int size = 0)
        {
            ////created the storyboard
            //var sb = new Storyboard();

            ////Add slide from left animation
            //sb.AddSlideFromLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            ////add fade in animation
            //sb.AddFadeIn(seconds);
            ////start animating
            //sb.Begin(element);

            //if (seconds != 0) //make a page visible ony when we are animating
            // //make the pag visiable
            //element.Visibility = Visibility.Visible;

            ////wait for it to finish
            //await Task.Delay((int)seconds * 1000);


            // Create the storyboard
            var sb = new Storyboard();

            // Slide in the correct direction
            switch (direction)
            {
                // Add slide from left animation
                case AnimationSlideInDirection.Left:
                    sb.AddSlideFromLeft(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                // Add slide from right animation
                case AnimationSlideInDirection.Right:
                    sb.AddSlideFromRight(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                // Add slide from top animation
                case AnimationSlideInDirection.Top:
                    sb.AddSlideFromTop(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
                // Add slide from bottom animation
                case AnimationSlideInDirection.Bottom:
                    sb.AddSlideFromBottom(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
            }

            //// Add slide from left animation
            //sb.AddSlideFromLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            // Add fade in animation
            sb.AddFadeIn(seconds);

            // Start animating
            sb.Begin(element);

            // Make page visible only if we are animating
            if (seconds != 0 || firstLoad)
                element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }


        /// <summary>
        /// Slides an element out to left 
        /// </summary>
        /// <param name="element">element to animate</param>
        /// <param name="seconds">the time the animation will take</param>
        ///  <param name="keepMargin">Whether to keep the element at the same width during the animation</param>
        ///  <param name="width">The animation width  to animate to, if not specified the element width is use</param>
        /// <returns></returns>
        //public static async Task SlideAndFadeOutToLeft(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
         public static async Task SlideAndFadeOutAsync(this FrameworkElement element, AnimationSlideInDirection direction, float seconds = 0.3f, bool keepMargin = true, int size = 0)
        {
           
            //created the storyboard
            var sb = new Storyboard();

            ////Add slide from left animation
            //sb.AddSlideToLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            // Slide in the correct direction
            switch (direction)
            {
                // Add slide from left animation
                case AnimationSlideInDirection.Left:
                    sb.AddSlideFromLeft(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                // Add slide from right animation
                case AnimationSlideInDirection.Right:
                    sb.AddSlideFromRight(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                // Add slide from top animation
                case AnimationSlideInDirection.Top:
                    sb.AddSlideFromTop(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
                // Add slide from bottom animation
                case AnimationSlideInDirection.Bottom:
                    sb.AddSlideFromBottom(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
            }
            //add fade in animation
            sb.AddFadeOut(seconds);


            //start animating
            sb.Begin(element);

            if (seconds != 0) //make a page visible ony when we are animating
              //make the pag visiable
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)seconds * 1000);

            //if (element.Opacity == 0)
                //make element invisible
                element.Visibility = Visibility.Hidden;
        }

        #endregion

        

        #region SlideAnd Fade in and out from RIGHT

        ///// <summary>
        ///// Slides an element in from the right
        ///// </summary>
        ///// <param name="element">element to animate</param>
        ///// <param name="seconds">the time the animation will take</param>
        /////  <param name="keepMargin">Whether to keep the element at the same width during the animation</param>
        ///// <param name="width">The animation width  to animate to, if not specified the element width is use</param>
        ///// <returns></returns>
        //public static async Task SlideAndFadeInFromRight(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        //{
        //    //created the storyboard
        //    var sb = new Storyboard();
        //    //Add slide from right animation
        //    sb.AddSlideFromRight(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

        //    // Slide in the correct direction
        //    switch (direction)
        //    {
        //        // Add slide from left animation
        //        case AnimationSlideInDirection.Left:
        //            sb.AddSlideFromLeft(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
        //            break;
        //        // Add slide from right animation
        //        case AnimationSlideInDirection.Right:
        //            sb.AddSlideFromRight(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
        //            break;
        //        // Add slide from top animation
        //        case AnimationSlideInDirection.Top:
        //            sb.AddSlideFromTop(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
        //            break;
        //        // Add slide from bottom animation
        //        case AnimationSlideInDirection.Bottom:
        //            sb.AddSlideFromBottom(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
        //            break;
        //    }
        //    ////add fade in animation
        //    //sb.AddFadeIn(seconds);


        //    ////start animating
        //    //sb.Begin(element);

        //    //if(seconds != 0) //Making zero invisbile from the start untill it needed
        //    ////make the pag visiable
        //    //element.Visibility = Visibility.Visible;

        //    ////wait for it to finish
        //    //await Task.Delay((int)seconds * 1000);


        //    // Add fade in animation
        //    sb.AddFadeIn(seconds);

        //    // Start animating
        //    sb.Begin(element);

        //    // Make page visible only if we are animating
        //    if (seconds != 0)
        //        // Make page visible only if we are animating or its the first load
        //        if (seconds != 0 || firstLoad)
        //            element.Visibility = Visibility.Visible;

        //    // Wait for it to finish
        //    await Task.Delay((int)(seconds * 1000));
        //}

        ///// <summary>
        ///// Slides an element out to right
        ///// </summary>
        ///// <param name="element">element to animate</param>
        ///// <param name="seconds">the time the animation will take</param>
        /////  <param name="keepMargin">Whether to keep the element at the same width during the animation</param>
        /////  <param name="width">The animation width  to animate to, if not specified the element width is use</param>
        ///// <returns></returns>
        //public static async Task SlideAndFadeOutToRight(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        // public static async Task SlideAndFadeOutAsync(this FrameworkElement element, AnimationSlideInDirection direction, float seconds = 0.3f, bool keepMargin = true, int size = 0)
        //{
        //    //created the storyboard
        //    var sb = new Storyboard();

        //    //Add slide from right animation
        //    sb.AddSlideToRight(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

        //    //add fade in animation
        //    sb.AddFadeOut(seconds);


        //    //start animating
        //    sb.Begin(element);

        //    if (seconds != 0) //make a page visible ony when we are animating
        //    //make the pag visiable
        //    element.Visibility = Visibility.Visible;

        //    //wait for it to finish
        //    await Task.Delay((int)seconds * 1000);


        //    //make element invisible
        //    element.Visibility = Visibility.Hidden;
        //}

        #endregion


        #region Slide And Fade in and out from BOTTOM

        ///// <summary>
        ///// Slides an element in from the bottom
        ///// </summary>
        ///// <param name="element">element to animate</param>
        ///// <param name="seconds">the time the animation will take</param>
        /////  <param name="keepMargin">Whether to keep the element at the same height during the animation</param>
        /////  <param name="height">The animation height  to animate to, if not specified the element height is use</param>
        ///// <returns></returns>
        //public static async Task SlideAndFadeInFromBottom(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int height = 0)
        //{
        //    //created the storyboard
        //    var sb = new Storyboard();

        //    //Add slide from bottom animation
        //    sb.AddSlideFromBottom(seconds, height == 0 ? element.ActualHeight : height, keepMargin: keepMargin);

        //    //add fade in animation
        //    sb.AddFadeIn(seconds);
        //    //start animating
        //    sb.Begin(element);

        //    if (seconds != 0) //make a page visible ony when we are animating
        //    //make the pag visiable
        //    element.Visibility = Visibility.Visible;

        //    //wait for it to finish
        //    await Task.Delay((int)seconds * 1000);
        //}


        ///// <summary>
        ///// Slides an element out to bottom 
        ///// </summary>
        ///// <param name="element">element to animate</param>
        ///// <param name="seconds">the time the animation will take</param>
        /////  <param name="keepMargin">Whether to keep the element at the same height during the animation</param>
        /////  <param name="height">The animation width  to animate to, if not specified the element height is use</param>
        ///// <returns></returns>
        //public static async Task SlideAndFadeOutToBottom(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int height = 0)
        //{
        //    //created the storyboard
        //    var sb = new Storyboard();

        //    //Add slide to bottom animation
        //    sb.AddSlideToBottom(seconds, height == 0 ? element.ActualHeight : height, keepMargin: keepMargin);

        //    switch (direction)
        //    {
        //        // Add slide to left animation
        //        case AnimationSlideInDirection.Left:
        //            sb.AddSlideToLeft(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
        //            break;
        //        // Add slide to right animation
        //        case AnimationSlideInDirection.Right:
        //            sb.AddSlideToRight(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
        //            break;
        //        // Add slide to top animation
        //        case AnimationSlideInDirection.Top:
        //            sb.AddSlideToTop(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
        //            break;
        //        // Add slide to bottom animation
        //        case AnimationSlideInDirection.Bottom:
        //            sb.AddSlideToBottom(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
        //            break;
        //    }
        //    //add fade in animation
        //    sb.AddFadeOut(seconds);


        //    //start animating
        //    sb.Begin(element);

        //    if(seconds != 0) //make a page visible ony when we are animating
        //    //make the pag visiable
        //    element.Visibility = Visibility.Visible;

        //    //wait for it to finish
        //    await Task.Delay((int)seconds * 1000);


        //    //make element invisible
        //    element.Visibility = Visibility.Hidden;
        //}

        #endregion


        
        #region Fade In / Out

        /// <summary>
        /// Fade an element in 
        /// </summary>
        /// <param name="element">element to animate</param>
        /// <param name="seconds">the time the animation will take</param>
        /// <returns></returns>
      
        public static async Task FadeInAsync(this FrameworkElement element, bool firstLoad, float seconds = 0.3f)
        {
            //created the storyboard
            var sb = new Storyboard();

            //add fade in animation
            sb.AddFadeIn(seconds);
            //start animating
            sb.Begin(element);

           //make a page visible only when we are animating
             if (seconds != 0 || firstLoad)
              //make the pag visiable
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }


        /// <summary>
        /// Fade an element out
        /// </summary>
        /// <param name="element">element to animate</param>
        /// <param name="seconds">the time the animation will take</param>
        /// <returns></returns>
        public static async Task FadeOutAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            //created the storyboard
            var sb = new Storyboard();

            //add fade in animation
            sb.AddFadeOut(seconds);
            //start animating
            sb.Begin(element);

            if (seconds != 0) //make a page visible only when we are animating
             //make the pag visiable
             element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)seconds * 1000);

            //Once we are done we make our visibility hidden (fully hide the element)
            element.Visibility = Visibility.Collapsed;
        }



        #endregion

        #region Marquee

        /// <summary>
        /// Animates a marquee style element
        /// The structure should be:
        /// [Border ClipToBounds="True"]
        ///   [Border local:AnimateMarqueeProperty.Value="True"]
        ///      [Content HorizontalAlignment="Left"]
        ///   [/Border]
        /// [/Border]
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static void MarqueeAsync(this FrameworkElement element, float seconds = 3f)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Run until element is unloaded
            var unloaded = false;

            // Monitor for element unloading
            element.Unloaded += (s, e) => unloaded = true;

            // Run a loop off the caller thread
            TaskManager.Run(async () =>
            {
                // While the element is still available, recheck the size
                // after every loop in case the container was resized
                while (element != null && !unloaded)
                {
                    // Create width variables
                    var width = 0d;
                    var innerWidth = 0d;

                    try
                    {
                        // Check if element is still loaded
                        if (element == null || unloaded)
                            break;

                        // Try and get current width
                        width = element.ActualWidth;
                        innerWidth = ((element as Border).Child as FrameworkElement).ActualWidth;
                    }
                    catch
                    {
                        // Any issues then stop animating (presume element destroyed)
                        break;
                    }

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        // Add marquee animation
                        sb.AddMarquee(seconds, width, innerWidth);

                        // Start animating
                        sb.Begin(element);

                        // Make page visible
                        element.Visibility = Visibility.Visible;
                    });

                    // Wait for it to finish animating
                    await Task.Delay((int)seconds * 1000);

                    // If this is from first load or zero seconds of animation, do not repeat
                    if (seconds == 0)
                        break;
                }
            });
        }

        #endregion
    }
}
