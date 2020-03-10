using System;
using System.Windows;

namespace CustomWindow.ViewModel
{
    /// <summary>
    /// View model for the Custom Flat Window
    /// </summary>
     public class WindowViewModel: BaseViewModel
     {
        #region Primate Member
        private Window mWindow;

        /// <summary>
        /// The margin around the window to allow for a drop shadow.
        /// </summary>
        private int mOuterMarginSize = 20;
        /// <summary>
        /// The radius of the edges of the window.
        /// </summary>
        private int mWindowRadius = 10;
        #endregion

        #region Public Properties
        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// Size of the resize border around the window, taking into account the outer margin.
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// The margin around the window to allow for a drop shadow.
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow.
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }
       

        /// <summary>
        /// The radius of the edges of the window.
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }
        /// <summary>
        /// The radius of the edges of the window.
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }
        #endregion
        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            //Listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                //Fire off events for all properties that are affected by a resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };
        }

       
        #endregion
    }
}
