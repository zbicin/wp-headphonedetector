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

            headsetResolver = new IsHeadsetResolver();
            DataContext = headsetResolver;
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
            MessageBox.Show("Prevent becoming an accidental bus DJ.\n\n©2014 Krzysztof Zbiciński\n\nFeel free to contact me: k.zbicinski@gmail.com.", "Headphones Status", MessageBoxButton.OK);
        }

    }
}