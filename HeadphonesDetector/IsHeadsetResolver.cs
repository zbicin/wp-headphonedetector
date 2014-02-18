using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Phone.Media.Devices;

namespace HeadphonesDetector
{
    public class IsHeadsetResolver : INotifyPropertyChanged
    {
        private bool _isHeadset;
        public bool IsHeadset
        {
            get { return _isHeadset; }
            set
            {
                _isHeadset = value;
                NotifyOfPropertyChange("IsHeadset");
            }
        }

        public IsHeadsetResolver()
        {
            IsHeadset = CheckForHeadset(AudioRoutingManager.GetDefault().GetAudioEndpoint());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool CheckForHeadset(AudioRoutingEndpoint endpoint)
        {
            return endpoint != AudioRoutingEndpoint.Default && endpoint != AudioRoutingEndpoint.Speakerphone;
        }

        protected virtual void NotifyOfPropertyChange(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                });
                
            }
        }

        public void AddNotificationHandler()
        {
            AudioRoutingManager.GetDefault().AudioEndpointChanged += AudioEndpointChanged_Handler;
        }

        public void RemoveNotificationHandler()
        {
            AudioRoutingManager.GetDefault().AudioEndpointChanged -= AudioEndpointChanged_Handler;
        }

        public void AudioEndpointChanged_Handler(AudioRoutingManager sender, object args)
        {
            var AudioEndPoint = sender.GetAudioEndpoint();
            IsHeadset = CheckForHeadset(AudioEndPoint);
        }
    }
}
