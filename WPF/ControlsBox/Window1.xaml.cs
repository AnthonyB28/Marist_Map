using System;
using System.Xml;
using System.Xml.Linq;
using System.Threading;
using System.Linq;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.ComponentModel;
using Microsoft.Surface;
using TweetSharp;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Input;
using Microsoft.Surface.Presentation.Controls;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Timers;
using System.Windows.Threading;


///
/// Main Window
/// ==================
/// Anthony Barranco
/// ==================
/// This is how the map is controlled.
/// There may be some old SDK example code here in.
/// Can be ignored or removed.
/// 
///
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
        public static bool lbview, scview, mcview, dnview, foyview, hcview = false;
        public static List<string> buildingNames;
        public static Dictionary<string, bool> detailView;
        public static Dictionary<Button, Line> linesDictionary;
        public static System.Timers.Timer twitterTimer;
        public static bool view, twitterview, headerLoaded;
        string directory;
        string AccessToken, AccessTokenSecret, ConsumerKey, ConsumerSecret;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Window1()
        {
            InitializeComponent();

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();

            linesDictionary = new Dictionary<Button, Line>();
            detailView = new Dictionary<string, bool>();
            buildingNames = new List<string>();

            //SETTINGS
            directory = @"C:\Users\barranca\Desktop\Map";
            AccessToken = "311447259-gOb7Tqj0sKH0ThtjfyRk6GciBoNrgc5TQzG62rzj";
            AccessTokenSecret = "loDhOBlidJGymxovu1FIpGwTryxDWkENVzYaal8g";
            ConsumerKey = "MG4D5DavXu7LeNDxM5JtA";
            ConsumerSecret = "Nb07qdPbdzIxaUsFKrZ294cfSa02ThcbI3ZfTY7cvc";

            //ADD BUILDING NAMES HERE
            buildingNames.Add("StudentCenter");
            buildingNames.Add("Library");
            buildingNames.Add("McCann");
            buildingNames.Add("Donnelly");
            buildingNames.Add("Foy");
            buildingNames.Add("Hancock");

            loadXml();

            foreach (string building in buildingNames)
            {
                detailView.Add(building, false);
            }

            //THIS IS TWITTER
            headerLoaded = false;
            LoadNewsLine();
            twitterTimer = new System.Timers.Timer(120000);
            twitterTimer.Enabled = true;
            twitterTimer.Elapsed += new ElapsedEventHandler(OnTwitterTimeEvent);
        }

        public void loadXml()
        {
            XmlDocument log = new XmlDocument();
            log.Load(directory+@"\BuildingDetails.xml");
            XmlNodeList myXML = log.SelectNodes("//Buildings/Building");
            foreach(XmlNode buildingNode in myXML)
            {
                XmlNode name = buildingNode.SelectSingleNode("//Name");
                XmlNode details = buildingNode.SelectSingleNode("//Detail");
                XmlNode deparments = buildingNode.SelectSingleNode("//Department");
                XmlNode phone = buildingNode.SelectSingleNode("//Phone");
                if(name.InnerText == "Hancock")
                {
                    hcBuildingInfo.Text = details.InnerText;
                    hcDepInfo.Text = deparments.InnerText;
                    hcPhoneInfo.Text = phone.InnerText;
                }
             }
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


        /// <summary>
        /// If the button is clicked with a MOUSE, call the movebox function.
        /// Passes in building name based on the button.
        /// Could have passed in the sender, but for the sake of readibility, just decided to pass strings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_click(object sender, RoutedEventArgs e)
        {
            string building;
            if (sender.Equals(StudentCenterButton) || sender.Equals(StudentCenterButtonX))
            {
                building = "SC";
                MoveBox(building);
            }
            if (sender.Equals(LibraryButton) || sender.Equals(LibraryButtonX))
            { 
                building = "LB";
                MoveBox(building);
            }
            if (sender.Equals(FoyButton))
            {
                building = "Foy";
                MoveBox(building);
            }
            if (sender.Equals(DonnellyButton) || sender.Equals(DonnellyButtonX))
            {
                building = "DN";
                MoveBox(building);
            }
            if (sender.Equals(McCannButton) || sender.Equals(McannButtonX))
            {
                building = "MC";
                MoveBox(building);
            }
            if (sender.Equals(HancockButton) || sender.Equals(HancockCloseButton))
            {
                building = "HC";
                MoveBox(building);
                
            }
            if (e.OriginalSource != null)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Same as click, but this is for the touch.
        /// Touch control can be simulated on non-touch computer with Surface SDK 2.0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement button = sender as FrameworkElement;
            if (button == null)
                return;

            TouchPoint tp = e.GetTouchPoint(button);
            Rect bounds = new Rect(new Point(0, 0), button.RenderSize);
            if (bounds.Contains(tp.Position))
            {
                button.ReleaseTouchCapture(e.TouchDevice);
                e.Handled = true;
                button_click(sender, new RoutedEventArgs());
            }

        }

        /// <summary>
        /// Moves the boxes based on name of parameter and if bool is false.
        /// If the bool view is true, then it will remove the box.
        /// Other logic such as line creation and drawers are handled too.
        /// </summary>
        /// <param name="building"></param>
        public void MoveBox(string building)
        {
            Line myLine = new Line();
            myLine.StrokeThickness = 2;
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
                    StudentCenter.Orientation = 0.0;
                    scview = false;

                }
            }
            else if (building.Equals("LB"))
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

            else if (building.Equals("DN"))
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
            else if (building.Equals("Foy"))
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
            else if (building.Equals("MC"))
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
            else if (building.Equals("HC"))
            {
                if (hcview == false)
                {
                    myLine.Stroke = System.Windows.Media.Brushes.Red;
                    BindLineToScatterViewItems(myLine, HancockButton, Hancock);
                    Hancock.Center = Point.Parse("900,500");
                    hcview = true;
                }
                else
                {
                    Hancock.Center = Point.Parse("1200,1200");
                    Hancock.Orientation = 0.0;
                    hcview = false;
                    if (detailView["Hancock"] == true) { slideDOutFull(HancockDetails, new RoutedEventArgs(), "Hancock"); }
                    myCanvas.Children.Remove(linesDictionary[HancockButton]);
                    linesDictionary.Remove(HancockButton);
                }
            }
        }

        /// <summary>
        /// Creates a line that connects the building and scatterview item.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        private void BindLineToScatterViewItems(Shape line, Button origin, ScatterViewItem destination)
        {
            // Bind line.(X1,Y1) to origin.ActualCenter
            Point p1 = origin.PointToScreen(new Point(0, 0));
            
            // Bind line.(X2,Y2) to destination.ActualCenter
            BindingOperations.SetBinding(line, Line.X2Property, new Binding { Source = destination, Path = new PropertyPath("ActualCenter.X"),Converter=new PlusTenConverter()});
            BindingOperations.SetBinding(line, Line.Y2Property, new Binding { Source = destination, Path = new PropertyPath("ActualCenter.Y") });
            Line myLine = line as Line;
            myLine.X1 = p1.X+50;
            myLine.Y1 = p1.Y;
            myCanvas.Children.Add(myLine);

            //Add the line object to the dictionary so that it can be removed when box is closed.
            linesDictionary.Add(origin, myLine);
        }

        /// <summary>
        /// Scatterview Invisibility
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnItemClicked(object sender, RoutedEventArgs e)
        {
            // Get the button that was clicked and hide it.
            ScatterView b = (ScatterView)e.Source as ScatterView;
            b.Visibility = Visibility.Visible;
        }


        /// <summary>
        /// This is the wrapper function for sliding details out. 
        /// The Detail button calls this function, which calls the full function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slideDOut(object sender, RoutedEventArgs e)
        {
            slideDOutFull(sender, e);
        }

        /// <summary>
        /// This function gets called by the wrapper or when a box is being closed.
        /// Creates an animation that 'slides' the drawer out from behind the scatterview item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="manual">Optional parameter for when drawer is being by building click.</param>
        private void slideDOutFull(object sender, RoutedEventArgs e, string manual = "Optional")
        {
            Grid target = null;
            Storyboard sb = new Storyboard();
            string buildingName;
            double x = 0.0, y = 0.0;
            view = false;
            if (manual != "Optional")
            {
                buildingName = manual;
            }

            else
            {
                ElementMenuItem buttonSend = sender as ElementMenuItem;
                buildingName = buttonSend.Name.Replace("DetailButton","");
            }

            if (buildingName == "Hancock")
            {
                x = hcDetailTransform.X;
                y = hcDetailTransform.Y;
                target = HancockDetails;  
            }


            DoubleAnimation slide = new DoubleAnimation();
            slide.From = x;
            slide.Duration = new Duration(TimeSpan.FromSeconds(0.4));

            //The detailView dictionary keeps track of what drawer is open and closed.
            if (detailView[buildingName] == false)
            {
                detailView[buildingName] = true;
                slide.To = 200.0 + x;
            }

            else if (detailView[buildingName] == true)
            {
                detailView[buildingName] = false;
                slide.To = x - 200.0;
                 view = true;
            }

            if (!view)
            {
                target.Visibility = Visibility.Visible;
                Storyboard fb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation(0, 1.0, TimeSpan.FromSeconds(0.3), FillBehavior.HoldEnd);
                // Set the target of the animation
                Storyboard.SetTarget(fade, target);
                Storyboard.SetTargetProperty(fade, new PropertyPath("(Opacity)"));

                // Kick the animation off
                fb.Children.Add(fade);
                fb.Begin();
            }

            // Set the target of the animation
            Storyboard.SetTarget(slide, target);
            Storyboard.SetTargetProperty(slide, new PropertyPath("(RenderTransform).(TranslateTransform.X)"));

            // Kick the animation off
            sb.Children.Add(slide);
            sb.Begin();

            if (e.OriginalSource != null)
            {
                e.Handled = true;
            }

            if (view)
            {
                Storyboard fb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation(1.0, 0.0, TimeSpan.FromSeconds(0.5), FillBehavior.HoldEnd); 
                // Set the target of the animation
                Storyboard.SetTarget(fade, target);
                Storyboard.SetTargetProperty(fade, new PropertyPath("(Opacity)"));

                // Kick the animation off
                fb.Children.Add(fade);
                fb.Begin();
            }
        }

        /// <summary>
        /// Handle tab control with touch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabItem_TouchDown(object sender, TouchEventArgs e)
        {
            TabItem tab = sender as TabItem;
            TabControl control = tab.Parent as TabControl;
            control.SelectedItem = tab;
            e.Handled = true;
        }

        /// <summary>
        /// Creates the Scatterview item for the photogallery.
        /// Must be called by the ElementMenuItem under a Scatterview item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addPhotoControlBox(object sender, RoutedEventArgs e)
        {
            var origin = ((ElementMenuItem)sender).Parent;
            var menu = ((ElementMenu)origin).Parent;
            var grid = ((Grid)menu).Parent;
            string building = ((ScatterViewItem)grid).Name;
            ScatterViewItem item = new ScatterViewItem();
            ImageButton gallery = new ImageButton(building);
            item.Content = gallery;
            item.Width = InteractiveSurface.PrimarySurfaceDevice.Bounds.Width / 3.2;
            item.Height = InteractiveSurface.PrimarySurfaceDevice.Bounds.Height / 3.2;
            item.Orientation = 0;
            item.Center = Point.Parse("708,200");
            MainScatterView.Items.Add(item);
        }

        public void LoadNewsLine()
        {
            twitterview = true;
            var coll = MaristInfo.FindResource("tweets") as Tweets;
            var head = MaristInfo.FindResource("heading") as Tweets;
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    var service = new TwitterService(ConsumerKey, ConsumerSecret);
                    service.AuthenticateWith(AccessToken, AccessTokenSecret);
                    IEnumerable<TwitterStatus> test = service.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions { ScreenName = "@marist", Count = 5, SinceId = null, MaxId = null });
                    IAsyncResult result = service.BeginListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions { ScreenName = "@marist", Count = 5, SinceId = null, MaxId = null });
                    IEnumerable<TwitterStatus> tweets = service.EndListTweetsOnHomeTimeline(result);

                    foreach (var tweet in tweets)
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(
                       DispatcherPriority.Normal,
                       (Action)delegate()
                       {
                           if (twitterview)
                           {
                               if (!headerLoaded)
                               {
                                   head.Add(new Tweet(tweet.User.ScreenName + " Twitter", "", tweet.User.ProfileImageUrl));
                                   headerLoaded = true;
                               }
                               coll.Add(new Tweet("-----------", tweet.Text, ""));
                               twitterview = false;
                           }
                           else
                           {
                               coll.Add(new Tweet("-----------", tweet.Text, ""));
                           }
                       });
                    }
                }
            }
            catch
            {
                System.Windows.Application.Current.Dispatcher.Invoke(
                       DispatcherPriority.Normal,
                       (Action)delegate()
                       {
                           if (!headerLoaded)
                           {
                               head.Add(new Tweet("Marist Twitter", "", ""));
                               headerLoaded = true;
                           }
                           coll.Add(new Tweet("-----------", "Connection Unnavailable", ""));
                       });
            }
            
        }

        private void OnTwitterTimeEvent(object source, ElapsedEventArgs e)
        {
            var coll = MaristInfo.FindResource("tweets") as Tweets;
                foreach (var item in coll.ToList())
                {
                    System.Windows.Application.Current.Dispatcher.Invoke(
                        DispatcherPriority.Normal,
                        (Action)delegate()
                        {
                            coll.Remove(item);
                        });
                }
            
            LoadNewsLine();
        }
    }

    /// <summary>
    /// For lines to connect the buildings, just adds to the converter parameter.
    /// </summary>
    public class PlusTenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value) + 100;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }

    public class Tweet
    {
           public String imgSrc { get; set; }
            public String user { get; set; }
            public String tweet { get; set; }

            public Tweet() { }

            public Tweet(String user, String tweet, String img)
            {
                this.imgSrc = img;
                this.user = user;
                this.tweet = tweet;
            }
    }

    public class Tweets : ObservableCollection<Tweet>
    {
        public Tweets()
        {
            
        }

        public void addTweet(Tweet tweet)
        {
            Add(tweet);
        }
    }
}