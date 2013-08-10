using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface.Presentation.Controls;


namespace ControlsBox
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ImageButton : UserControl
    {
        public static string building;
        public static SurfaceButton savedButton;

        public ImageButton()
        {
            InitializeComponent();
        }
        public ImageButton(string building)
        {
            InitializeComponent();
            Building.Text = building;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // Query the registry to find out where sample photos are stored.
            const string shellKey =
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\explorer\Shell Folders";

            string imagesPath =
                (string)Microsoft.Win32.Registry.GetValue(shellKey, "CommonPictures", null) + @"\Sample Pictures";

            try
            {
                // Get a list of all .jpg files.
                string[] imageNames = System.IO.Directory.GetFiles(imagesPath, "*.jpg");

                // Make sure that there are some images to select.
                if (imageNames.Length > 0)
                {
                    Random randomIndex = new Random();
                    // This list tracks which images have been added to buttons 
                    // so that no two buttons have the same image.
                    List<int> selected = new List<int>();

                    foreach (UIElement element in MainGrid.Children)
                    {
                        SurfaceButton button = element as SurfaceButton;
                        if (button != null)
                        {
                            // Track the number of tries. 
                            // This item is to prevent an endless loop if there
                            // are fewer images to choose from than buttons.
                            int tryCount = 0;
                            int index = randomIndex.Next(imageNames.Length);
                            while (selected.Contains(index) && tryCount < 8)
                            {
                                index = randomIndex.Next(imageNames.Length);
                                tryCount++;
                            }
                            // Create the image and assign it to the button content.
                            BitmapImage bitmap = new BitmapImage(new Uri(imageNames[index]));
                            Image image = new Image();
                            image.Source = bitmap;
                            button.Content = image;
                            // Track that this index has been used.
                            selected.Add(index);
                        }
                    }
                }
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                // Handle exceptions as needed.
            }
        }
        private void SurfaceButton_Click(object sender, RoutedEventArgs e)
        {
            CloseUserControl((SurfaceButton)sender);
        }


        /// <summary>
        /// Close the user control. 
        /// Move the content of the button to the ScatterViewItem control.
        /// Do not remove the ScatterViewItem control.
        /// </summary>
        private void CloseUserControl(SurfaceButton button)
        {
            DependencyObject parent = LogicalTreeHelper.GetParent(button);
            back.IsEnabled = true;
            while (parent != null)
            {
                UIElement item = parent as UIElement;
                if (item != null)
                {
                    // Put the content of the button into
                    // the content of the ScatterViewItem control.
                    object content = button.Content;
                    object menu = MenuButton;
                    
                    //Picture.Children.Remove(MainGrid);
                    button.Content = null;
                    savedButton = button;
                    MainGrid = null;
                    //item.Content = content;
                    Picture.Children.Add((content as UIElement) );
                    return;
                }
                // Get the next parent.
                parent = LogicalTreeHelper.GetParent(parent);
            }
        }

        private void backToGallery(object sender, RoutedEventArgs e)
        {
            savedButton.Content = VisualTreeHelper.GetChild(Picture, 0);
            Picture.Children.RemoveAt(0);
            back.IsEnabled = false;
            e.Handled = true;
        }

        private void closePhotoWindow(object sender, RoutedEventArgs e)
        {
            ScatterViewItem var = ((ScatterViewItem)this.Parent);
            ((ScatterView)var.Parent).Items.Remove(var);
        }

        
       
    }
}
