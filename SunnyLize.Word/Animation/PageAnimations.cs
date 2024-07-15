
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SunnyLize.Word
{
    /// <summary>
    /// Helpers to static pages in specific ways
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        /// Slides to page in from the right
        /// </summary>
        /// <param name="page">page to animate</param>
        /// <param name="seconds">the time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight (this Page page, float seconds)
        {
            //created the storyboard
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            //add fade in animation
            sb.AddFadeIn(seconds);          

            //start animating
            sb.Begin(page);

            //make the pag visiable
            page.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }


        /// <summary>
        /// Slides the page out to left 
        /// </summary>
        /// <param name="page">page to animate</param>
        /// <param name="seconds">the time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            //created the storyboard
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideToLeft(seconds, page.WindowWidth);
            
            //add fade in animation
            sb.AddFadeOut(seconds);


            //start animating
            sb.Begin(page);

            //make the pag visiable
            page.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }
    }
}
