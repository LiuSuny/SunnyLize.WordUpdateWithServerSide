
using System.Runtime.InteropServices;
using System;
using System.Windows;
using System.Windows.Input;
using SunnyLize.Word.Core;

namespace SunnyLize.Word
{
    
    /// <summary>
    /// View model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Valuable_store

         /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The window resizer helper that keeps the window size correct in various states
        /// </summary>
        private WindowResizer mWindowResizer;

        /// <summary>
        /// The margine around the window to allow for a drop shadow
        /// </summary>
        private int  mOuterMargineSize = 10;

        /// <summary>
        /// The radius of the edges f window
        /// </summary>
        private int mWindowRadius = 10;

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;
        #endregion

        #region public properties

        /// <summary>
        /// The smallest width the window can go to when minimizing our window
        /// </summary>
        public double WindowMinimiumWidth { get; set; } = 800;

        /// <summary>
        /// The smallest height the window can go to when minimizing our window
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 500;


        /// <summary>
        /// True if the window should be borderless because it is docked or maximized
        /// </summary>
        public bool Borderless => (mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked);

        ///// <summary>
        ///// The size of the resize border around the window
        ///// </summary>
        ////public int ResizeBorder { get; set; } = 6;
        //public int ResizeBorder => Borderless ? 0 : 6; //{ get { return Borderless ? 0 : 6; } } 

        /// <summary>
        /// The size of the resize border around the window and it help with max and minimize with window using mouse
        /// </summary>
        public int ResizeBorder => mWindow.WindowState == WindowState.Maximized ? 0 : 4;

        /// <summary>
        /// The size of the resize border around the window taking into account the outermargin
        /// { get{ return new Thickness(ResizeBorder + OuterMargineSize); } }
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMargineSize);

        /// <summary>
        /// The padding of the Inner content of main window
        /// 
        /// </summary>
       // public Thickness InnerContentPadding { get { return new Thickness(ResizeBorder);} } 
        public Thickness InnerContentPadding { get; set; } = new Thickness(0); 


        /// <summary>
        /// The margine around the window to allow for a drop shadow
        /// </summary>
        public int OuterMargineSize
        {
            //get
            //{
            //    //return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMargineSize;

            //    //meaning if it is maximized or docked, then no border
            //    return Borderless ? 0 : mOuterMargineSize;
            //}
            //set
            //{
            //    mOuterMargineSize = value;
            //}

            get => Borderless ? 0 : mOuterMargineSize; 
            set => mOuterMargineSize = value;
            
              
            
        }

        /// <summary>
        /// The margine around the window to allow for a drop shadow
        /// { get { return new Thickness(OuterMargineSize); } }
        /// </summary>
        public Thickness OuterMargineSizeThickness => new Thickness(OuterMargineSize);
           
        /// <summary>
        /// The radius of the edges f window
        /// </summary>
        public int WindowRadius
        {
            //get
            //{
            //    return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            //}
            //set
            //{
            //    mWindowRadius = value;
            //}

            //get => mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            //set => mWindowRadius = value;

            get => Borderless ? 0 : mWindowRadius;
            set => mWindowRadius = value;

        }

        /// <summary>
        /// The radius of the edges f window
        /// { get { return new CornerRadius(WindowRadius); } }
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        /// <summary>
        /// The height of the title bar/caption of the window
        /// { get { return new GridLength(TitleHeight + ResizeBorder); } }
        /// </summary>
        public int TitleHeight { get; set; } = 42;
        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        /// <summary>
        /// True if we should have a dimmed overlay on the window
        /// such as when a popup is visible or the window is not focused
        /// </summary>
        public bool DimmableOverlayVisible { get; set; }

        ///// <summary>
        ///// True if we should show the setting menu
        ///// </summary>
        //public bool SettingsMenuVisible
        //{
        //    get => IOCContainer.Application.SettingsMenuVisible;
        //    set => IOCContainer.Application.SettingsMenuVisible = value;
        //}
        #endregion


        #region Commands

        /// <summary>
        /// the command to minimized our window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// the command to maximized our window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// the command to close our window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// the command for window ssystem menu
        /// </summary>
        public ICommand MenuCommand { get; set; }
        #endregion


        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            //Listen out for the window resizing when the state changes
            mWindow.StateChanged += (sender, e) =>
            {
                // Fire off events for all properties that are affected by a resize
                WindowResized();
               
            };

            //Creating a command
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized); //minimize window
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized); //maximize window using Dock
            CloseCommand = new RelayCommand(() => mWindow.Close()); //close command window 
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition())); //menu command window 

            ////Fix window resize issue
            //var resizer = new WindowResizer(mWindow);

            // Fix window resize issue
            mWindowResizer = new WindowResizer(mWindow);

            // Listen out for dock changes
            mWindowResizer.WindowDockChanged += (dock) =>
            {
                // Store last position
                mDockPosition = dock;

                // Fire off resize events
                WindowResized();
            };
        }

        private void WindowResized()
        {
            //we implement all our event everytime there is change in our activity
            //fire of event for all properties that are affected by a resize
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMargineSize));
            OnPropertyChanged(nameof(OuterMargineSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
            
        }

        #endregion

        #region Private Helper


        /// <summary>
        /// Get the current mouse position on the creen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            //The position of the mouse relative  to the window
            var position = Mouse.GetPosition(mWindow);

            //Add the window psition
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);


        }
        #endregion
    }
}
