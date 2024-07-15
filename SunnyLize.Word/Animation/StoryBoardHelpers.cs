

using System.Windows;
using System;
using System.Windows.Media.Animation;

namespace SunnyLize.Word
{
    /// <summary>
    /// Animation helpers for <see cref="Storyboard"/>
    /// </summary>
    public static class StoryBoardHelpers
    {

        #region Sliding To/From LEFT
      
        /// <summary>
        /// Add a slide from left animation to the story board
        /// </summary>
        /// <param name="storyboard">The stroyboard to add from right animation to</param>
        /// <param name="seconds">the time the animatio will take</param>
        /// <param name="offset"> the distance to the left to start from</param>
        /// <param name="decelerationRatio">the rate of acceleration</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during the animation</param>
        public static void AddSlideFromLeft(this Storyboard storyboard,
            float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Create the margin animate from right 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }

      

        /// <summary>
        /// Add a slide from left animation to the story board
        /// </summary>
        /// <param name="storyboard">The stroyboard to add left animation to</param>
        /// <param name="seconds">the time the animatio will take</param>
        /// <param name="offset"> the distance to the left to end at</param>
        /// <param name="decelerationRatio">the rate of acceleration</param>
        ///  <param name="keepMargin">Whether to keep the element at the same width during the animation</param>
        public static void AddSlideToLeft(this Storyboard storyboard,
            float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Create the margin animate from right 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                DecelerationRatio = decelerationRatio
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }

        #endregion


        #region Sliding To/From RIGHT

        /// <summary>
        /// Add a slide from right animation to the story board
        /// </summary>
        /// <param name="storyboard">The stroyboard to add from right animation to</param>
        /// <param name="seconds">the time the animatio will take</param>
        /// <param name="offset"> the distance to the right to start from</param>
        /// <param name="decelerationRatio">the rate of acceleration</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during the animation</param>
        public static void AddSlideFromRight(this Storyboard storyboard,
            float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Create the margin animate from right 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }


        /// <summary>
        /// Add a slide from right animation to the story board
        /// </summary>
        /// <param name="storyboard">The stroyboard to add left animation to</param>
        /// <param name="seconds">the time the animatio will take</param>
        /// <param name="offset"> the distance to the right to end at/param>
        /// <param name="decelerationRatio">the rate of acceleration</param>
        ///  <param name="keepMargin">Whether to keep the element at the same width during the animation</param>
        public static void AddSlideToRight(this Storyboard storyboard,
           float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Create the margin animate from right 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                DecelerationRatio = decelerationRatio
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }

        #endregion


        #region Sliding To/From Top

        /// <summary>
        /// Adds a slide from top animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The distance to the top to start from</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        /// <param name="keepMargin">Whether to keep the element at the same height during animation</param>
        public static void AddSlideFromTop(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Create the margin animate from right 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0, -offset, 0, keepMargin ? offset : 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide to top animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The distance to the top to end at</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        /// <param name="keepMargin">Whether to keep the element at the same height during animation</param>
        public static void AddSlideToTop(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Create the margin animate from right 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(0, -offset, 0, keepMargin ? offset : 0),
                DecelerationRatio = decelerationRatio
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }

        #endregion

        #region Sliding To/From BOTTOM

        /// <summary>
        /// Add a slide from bottom animation to the story board
        /// Note:sliding bottom basically mean we are sliding up
        /// </summary>
        /// <param name="storyboard">The stroyboard to add from bottom animation to</param>
        /// <param name="seconds">the time the animatio will take</param>
        /// <param name="offset"> the distance to the bottom to start from</param>
        /// <param name="decelerationRatio">the rate of acceleration</param>
        /// <param name="keepMargin">Whether to keep the element at the same height during the animation</param>
        public static void AddSlideFromBottom(this Storyboard storyboard,
            float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            //created margin animation from right
            var Animation = new ThicknessAnimation
            {
                //Note: when animating from the bottom we start  zer0(0) have in mind of
                //keeping the top margin at zero, left is zero while the bottom is
                //from negative (-offset) as that is where the animate will be sliding and
                //popingout from
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0, keepMargin ? offset : 0, 0, -offset),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            //setting the target property name
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));
            //add this to the storyboard
            storyboard.Children.Add(Animation);
        }



        /// <summary>
        /// Add a slide to bottom animation to the story board
        /// </summary>
        /// <param name="storyboard">The stroyboard to add bottom animation to</param>
        /// <param name="seconds">the time the animatio will take</param>
        /// <param name="offset"> the distance to the bottom to end at</param>
        /// <param name="decelerationRatio">the rate of acceleration</param>
        ///  <param name="keepMargin">Whether to keep the element at the same height during the animation</param>
        public static void AddSlideToBottom(this Storyboard storyboard,
            float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            //created margin animation from right
            var Animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness (0, keepMargin ? offset : 0, 0, -offset),
                DecelerationRatio = decelerationRatio
            };
            //setting the target property name
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));
            //add this to the storyboard
            storyboard.Children.Add(Animation);
        }

        #endregion

        #region Fade In/Out 
        /// <summary>
        /// Add a slide fade in animation to the story board
        /// </summary>
        /// <param name="storyboard">The stroyboard to add fade in animation to</param>
        /// <param name="seconds">the time the animatio will take</param>

        public static void AddFadeIn(this Storyboard storyboard,  float seconds)          
        {
            //created margin animation from right
            var Animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1
               
            };

            //setting the target property name
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Opacity"));
            //add this to the storyboard
            storyboard.Children.Add(Animation);
        }



        /// <summary>
        /// Add a slide fade out animation to the story board
        /// </summary>
        /// <param name="storyboard">The stroyboard to add fade out animation to</param>
        /// <param name="seconds">the time the animatio will take</param>

        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            //created margin animation from right
            var Animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0

            };

            //setting the target property name
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Opacity"));
            //add this to the storyboard
            storyboard.Children.Add(Animation);
        }

        #endregion

        /// <summary>
        /// Adds a marquee scrolling right to left animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="contentOffset">The inner contents size, to start the marquee as soon as that content has scrolled out of view</param>
        /// <param name="offset">The offset of the parent to scroll within</param>
        public static void AddMarquee(this Storyboard storyboard, float seconds, double offset = 0, double contentOffset = 0)
        {
            // Create the margin animate from right to left
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(-contentOffset, 0, contentOffset, 0),
                RepeatBehavior = RepeatBehavior.Forever
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }
    }
}
