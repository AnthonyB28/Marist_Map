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
        public static bool lbview, scview, mcview, dnview, foyview = false;

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
                if (scview == false)
                {
                    StudentCenter.Center = Point.Parse("600,600");
                    scview = true;
                }
               
                else
                {
                    StudentCenter.Center = Point.Parse("1200,1200");
                    scview = false;
                }
            }
            if (building.Equals("LB"))
            {
                if (lbview == false)
                {
                    Library.Center = Point.Parse("900,600");
                    lbview = true;
                }
                else
                {
                    Library.Center = Point.Parse("1200,1200");
                    lbview = false;
                }
            }

            if (building.Equals("DN"))
            {
                if (dnview == false)
                {
                    Donnelly.Center = Point.Parse("1000,800");
                    dnview = true;
                }

                else
                {
                    Donnelly.Center = Point.Parse("1200,1200");
                    dnview = false;
                }
            }
            if (building.Equals("Foy"))
            {
                if (foyview == false)
                {
                    Foy.Center = Point.Parse("1000,450");
                    foyview = true;
                }
                else
                {
                    Foy.Center = Point.Parse("1200,1200");
                    foyview = false;
                }
            }
            if (building.Equals("MC"))
            {
                if (mcview == false)
                {
                    McCann.Center = Point.Parse("200,850");
                    mcview = true;
                }
                else
                {
                    McCann.Center = Point.Parse("1200,1200");
                    mcview = false;
                }
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
            if (sender.Equals(LibraryButton))
            {
                building = "LB";
                MoveBox(building);
            }
            if (sender.Equals(FoyButton))
            {
                building = "Foy";
                MoveBox(building);
            }
            if (sender.Equals(DonnellyButton))
            {
                building = "DN";
                MoveBox(building);
            }
            if (sender.Equals(McCannButton))
            {
                building = "MC";
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
                     if (sender.Equals(LibraryButton))
                     {
                         building = "LB";
                         MoveBox(building);
                     }
                     if (sender.Equals(FoyButton))
                     {
                         building = "Foy";
                         MoveBox(building);
                     }
                     if (sender.Equals(DonnellyButton))
                     {
                         building = "DN";
                         MoveBox(building);
                     }
                     if (sender.Equals(McCannButton))
                     {
                         building = "MC";
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