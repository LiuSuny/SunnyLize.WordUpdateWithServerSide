
using SunnyLize.Word.Core;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static SunnyLize.Word.DI;

namespace SunnyLize.Word
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        //propdp - shortcut to implement our previous dependency property

        

        #region Dependency Property
        /// <summary>
        /// The current page to show in the host page
        /// </summary>
        public ApplicationPage CurrentPage
        {
            get => (ApplicationPage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        /// <summary>
        /// Register <see cref="CurrentPage"/> as a dependency property
        /// Using a DependencyProperty as the backing store for CurrentPage.  This enables animation, styling, binding, etc...
        /// </summary>

        public static readonly DependencyProperty CurrentPageProperty =
           DependencyProperty.Register(nameof(CurrentPage), typeof(ApplicationPage), typeof(PageHost),
               new UIPropertyMetadata(default(ApplicationPage), null, CurrentPagePropertyChanged));



        /// <summary>
        /// The current page to show in the host page
        /// </summary>
        public BaseViewModel CurrentPageViewModel
        {
            get => (BaseViewModel)GetValue(CurrentPageViewModelProperty);
            set => SetValue(CurrentPageViewModelProperty, value);
        }

        /// <summary>
        /// Register <see cref="CurrentPageViewModel"/> as a dependency property
        /// Using a DependencyProperty as the backing store for CurrentPage.  This enables animation, styling, binding, etc...
        /// </summary>

        public static readonly DependencyProperty CurrentPageViewModelProperty =
           DependencyProperty.Register(nameof(CurrentPageViewModel), typeof(BaseViewModel), typeof(PageHost),
               new UIPropertyMetadata());


        #endregion

        #region Constructor
        /// <summary>
        /// default constructor
        /// </summary>
        public PageHost()
        {
            InitializeComponent();

            //If we are in design mode show the cureent page
            //as the dependency doesn't fire
            if (DesignerProperties.GetIsInDesignMode(this))
                //just for the designer we basically take the currentpage and convert it to basepage just only for the designer
                //NewPage.Content = IOCContainer.Application.CurrentPage.ToBasePage();
                //NewPage.Content = new ApplicationViewModel().CurrentPage.ToBasePage();
                NewPage.Content = ViewModelApplication.CurrentPage.ToBasePage();


        }
        #endregion


        #region Property Change Event
        /// <summary>
        /// call when the <see cref="CurrentPage"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static object CurrentPagePropertyChanged(DependencyObject d, object value)
        {
            //Get current value
            var currentPage = (ApplicationPage)d.GetValue(CurrentPageProperty);
            var currentPageViewModel = d.GetValue(CurrentPageViewModelProperty);

            //Getting the frame
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            //if the currentpage has not change then just update the view model 
            if (newPageFrame.Content is BasePage page
                && page.ToApplicationPage() == currentPage)

            {
                //just update the view model
                page.ViewModelObject = currentPageViewModel;

                return value;
            }


            //Next we store the current page content as the old page
            var oldePageContent = newPageFrame.Content;

            //Remove current page from new page frame
            newPageFrame.Content = null;

            //Next we move the previous page into the old page frame
            oldPageFrame.Content = oldePageContent;

            //Animate out the previous page when loaded event is fire
            //right after the call due to moving frames
            if (oldePageContent is BasePage oldPage)
            {
                // oldPage.AniminateOut(); //encounter warning error but to get ride of with implement the following
                //Task.Run(oldPage.AniminateOut);

                //Tell old page to animateOut
                oldPage.ShouldAnimateOut = true;

                //Once it is done remove it
                Task.Delay((int)oldPage.SlideSeconds * 1000).ContinueWith((t) =>
                {
                    //remove old page
                    Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);

                });
            }

            //setting up the new page content
            newPageFrame.Content = currentPage.ToBasePage(currentPageViewModel);

            return value;
        } 
        #endregion


    }
}
