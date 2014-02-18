using HeadphonesDetector.Resources;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Windows.Phone.Media.Devices;

namespace HeadphonesDetector
{
    public partial class MainPage : PhoneApplicationPage
    {
        private string endpointName { get; set; }
        private IsHeadsetResolver headsetResolver { get; set; }

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            //this.endpointName = AudioEndPointToString(AudioRoutingManager.GetDefault().GetAudioEndpoint());
            //tbEndpointName.DataContext = this.endpointName;
            headsetResolver = new IsHeadsetResolver();
            tbDescription.DataContext = headsetResolver;
            tbIcon.DataContext = headsetResolver;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            headsetResolver.AddNotificationHandler();
        }

        private void PhoneApplicationPage_Unloaded(object sender, RoutedEventArgs e)
        {
            headsetResolver.RemoveNotificationHandler();
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("©2014 Krzysztof Zbiciński\r\n\r\nFeel free to contact me: fistasheq@gmail.com.", "About the author", MessageBoxButton.OK);
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