using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using HeadphonesDetector.Resources;
using Windows.Phone.Media.Devices;

namespace HeadphonesDetector
{
    public partial class MainPage : PhoneApplicationPage
    {
        public String HeadphonesState;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

           
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Load");
            //(this.LayoutRoot.DataContext as AudioPathResolver).AddNotificationHandler();
        }

        private void PhoneApplicationPage_Unloaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Unload");
            //(this.LayoutRoot.DataContext as AudioPathResolver).RemoveNotificationHandler();
        

        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            AudioRoutingEndpoint audioRoutingEndpoint = AudioRoutingManager.GetDefault().GetAudioEndpoint();
            
            if (audioRoutingEndpoint == AudioRoutingEndpoint.Default
                || audioRoutingEndpoint == AudioRoutingEndpoint.Speakerphone)
            {
                MessageBox.Show("Speakers on!");
            }
            else
            {
                MessageBox.Show("Headphones plugged in");
            }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}