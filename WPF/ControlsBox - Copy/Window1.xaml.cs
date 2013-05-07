using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.ComponentModel;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Input;
using Microsoft.Surface.Presentation.Controls;

namespace ControlsBox
{

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : SurfaceWindow
    {
        private readonly ObservableCollection<ImageInfo> images = new ObservableCollection<ImageInfo>();
        private readonly ObservableCollection<ImageInfo> images2 = new ObservableCollection<ImageInfo>();
        public static System.Windows.Point contactPosition;
        public static readonly RoutedCommand ShowMessageCommand = new RoutedCommand("ShowMessage", typeof(Window1));

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Window1()
        {
            InitializeComponent();

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();
          



        }

        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

           

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

  

        /// <summary>
        /// Change the content of the display area to show the newly selected control.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event args.</param>
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SurfaceListBoxItem selectedItem = (SurfaceListBoxItem)ContentSelector.SelectedItem;
            Grid content = selectedItem.Tag as Grid;
            if (content != null)
            {
                foreach (SurfaceDragCursor cursor in SurfaceDragDrop.GetAllCursors(this))
                {
                    SurfaceDragDrop.CancelDragDrop(cursor);
                }

                ContentArea.Children.Clear();
                ContentArea.Children.Add(content);
            }
        }  
        
        
                


        private void SurfaceListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

       // public static void MoveToContactPositon(ScatterViewItem svi, Point p)
        //{
         //   PointAnimation pointAnimation = new PointAnimation(svi.Center, p, TimeSpan.FromSeconds(1), FillBehavior.Stop);
         //   pointAnimation.AccelerationRatio = 0.8;
         //   pointAnimation.DecelerationRatio = 0.2;
         //   pointAnimation.FillBehavior = FillBehavior.Stop;
         //   pointAnimation.Completed += delegate(object send, EventArgs ev)
         //   {
         //       svi.Center = svi.ActualCenter;
          //      svi.CanMove = true;
         //   };
         //   svi.BeginAnimation(ScatterViewItem.CenterProperty, pointAnimation);

        // }

        public void MoveBox(string building)
        {
            if (building.Equals("SC"))
            {
                StudentCenter.Center = Point.Parse("450,500");
            }
        }

        private void button_click(object sender, RoutedEventArgs e)
        {
            string building;
            if (sender.Equals(StudentCenterButton))
            {
                building = "SC";
                MoveBox(building);
            }
        }

        private void button_TouchDown(object sender, TouchEventArgs e)
        {
             string building;
             FrameworkElement button = sender as FrameworkElement;
             if (button == null)
                 return;

                TouchPoint tp = e.GetTouchPoint(button);
                Rect bounds = new Rect(new Point(0, 0), button.RenderSize);
                if (bounds.Contains(tp.Position))
                 {
                     if (sender.Equals(StudentCenterButton))
                     {
                         building = "SC";
                         MoveBox(building);
                     } 
                 }
                
                button.ReleaseTouchCapture(e.TouchDevice);
     
                 e.Handled = true;
        }

        private void OnItemClicked(object sender, RoutedEventArgs e)
        {
            // Get the button that was clicked and hide it.
            ScatterView b = (ScatterView)e.Source as ScatterView;
            b.Visibility = Visibility.Visible;
        }


    }
}