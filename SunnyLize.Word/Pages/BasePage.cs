

using Dna;
using SunnyLize.Word.Animation;
using SunnyLize.Word.Core;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SunnyLize.Word
{
    /// <summary>
    /// Base page for all pages to gain base functionality
    /// </summary>
    public class BasePage: UserControl
    {

        #region Private memeber
        /// <summary>
        /// View models associated with this page
        /// </summary>
        private object mViewModel { get; set; }

        #endregion

        #region Public Properties
        /// <summary>
        /// The animation that play when the page is first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// The animation that play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnLoadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// the time the animation take to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.4f;

        /// <summary>
        /// Aflag to indicate  if this page should animate when is on load
        /// usefull for when we are moving the page to another frame
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        

        /// <summary>
        /// View models associated with this page
        /// </summary>
        public object ViewModelObject
        {
            get =>  mViewModel; 
            set
            {
                //if nothing change, return nothing
                if (mViewModel == value)
                    return;
                //otherwise update the value
                mViewModel = value;

                //Once our view model is updated fire the view model change
                OnviewModelChange();

                //set our datacontext to viewmodel on this page
                DataContext = mViewModel;
            }
        }

        #endregion


        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public BasePage()
        {
            //IF at we don't want to bother or worrying animating during design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return; //this basically mean if we are in design time don't bother animating

            //if we are animating in, hide to begin with
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            //Listening out for the page loaded
            Loaded += BasePage_Loaded;
          
            
        }
        #endregion




        #region Animation Load/Unload

        /// <summary>
        /// Once the page is loaded it required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
           
            //if we are setup to animate out on load
            if (ShouldAnimateOut)
                //animate ut
                await AniminateOut();
            //otherwise....
            else
            //Animate in this page 
            await AnimateIn();
        }

        /// <summary>
        /// AnimateIn in this page
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            //Trying to make sure we have something to do
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    
                    //start the animation
                   // await this.SlideAndFadeInFromRight(SlideSeconds, width: (int)Application.Current.MainWindow.Width); //we can decide to remove the *5 and it will slide in faster
                    await this.SlideAndFadeInAsync(AnimationSlideInDirection.Right, false, SlideSeconds, size: (int)Application.Current.MainWindow.Width);
                    break;
            }
        }

        /// <summary>
        /// Animate the page out
        /// </summary>
        /// <returns></returns>
        public async Task AniminateOut()
        {
            //Trying to make sure we have something to do
            if (PageUnLoadAnimation == PageAnimation.None)
                return;

            switch (PageUnLoadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    //start the animation
                    //await this.SlideAndFadeOutToLeft(SlideSeconds /*width: (int)Application.Current.MainWindow.Width*/); //we can decide to remove the *5 and it will slide in faster
                    await this.SlideAndFadeOutAsync(AnimationSlideInDirection.Left, SlideSeconds);

                    break;
            }
        }
        #endregion

        /// <summary>
        /// Fire when the view model changes
        /// </summary>
        protected virtual void OnviewModelChange()
        {

        }

    }





    /// <summary>
    /// Base page for added viewmodel support
    /// </summary>
    public class BasePage<VM>: BasePage
        where VM : BaseViewModel, new()
    {



        #region Public Properties
        /// <summary>
        /// The view model associated with this page
        /// </summary>
        public VM ViewModel
        {
            get => (VM)ViewModelObject;

            set => ViewModelObject = value;
        }
            
        #endregion

        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>

        public BasePage() : base()
        {
            //IF we are design time mode
            if (DesignerProperties.GetIsInDesignMode(this))
                //then just use new instance of the VM
                ViewModel = new VM();
            else
            //Otherwise we create a default ViewModel
            this.ViewModel =Framework.Service<VM>() ?? new VM();
        }


        /// <summary>
        /// ctor with arguments
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use if any</param>
        public BasePage(VM specificViewModel = null) : base()
        {


            // this.ViewModel = new VM();

            //set the specific view model
            if (specificViewModel != null)
                ViewModel = specificViewModel;
            else
            {
                //IF we are design time mode
                if (DesignerProperties.GetIsInDesignMode(this))
                    //then just use new instance of the VM
                    ViewModel = new VM();
                else
                {
                     //Otherwise we create a default ViewModel
                    this.ViewModel = Framework.Service<VM>() ?? new VM();
                }
                 
            }
           
        }
        #endregion


    }
}
