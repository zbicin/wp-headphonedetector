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
    public class AudioPathResolver : INotifyPropertyChanged
    {
        private string _audioPath;
        public string AudioPath
        {
            get { return _audioPath; }
            set
            {
                _audioPath = value;
                NotifyOfPropertyChange("AudioPath");
            }
        }

        public AudioPathResolver()
        {
            AudioPath = AudioEndPointToString(AudioRoutingManager.GetDefault().GetAudioEndpoint());
        }

        public event PropertyChangedEventHandler PropertyChanged;


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
            AudioPath = AudioEndPointToString(AudioEndPoint);
        }

        private string AudioEndPointToString(AudioRoutingEndpoint AudioEndPoint)
        {
            string audioEndPointString;
            switch (AudioEndPoint)
            {
                case AudioRoutingEndpoint.Default:
                    {
                        audioEndPointString = "Default";
                        break;
                    }
                case AudioRoutingEndpoint.Earpiece:
                    {
                        audioEndPointString = "Earpiece";
                        break;
                    }
                case AudioRoutingEndpoint.Speakerphone:
                    {
                        audioEndPointString = "Speakerphone";
                        break;
                    }
                case AudioRoutingEndpoint.Bluetooth:
                    {
                        audioEndPointString = "Bluetooth";
                        break;
                    }
                case AudioRoutingEndpoint.WiredHeadset:
                    {
                        audioEndPointString = "WiredHeadset";
                        break;
                    }
                case AudioRoutingEndpoint.WiredHeadsetSpeakerOnly:
                    {
                        audioEndPointString = "WiredHeadsetSpeakerOnly";
                        break;
                    }
                case AudioRoutingEndpoint.BluetoothWithNoiseAndEchoCancellation:
                    {
                        audioEndPointString = "BluetoothWithNoiseAndEchoCancellation";
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return audioEndPointString;
        }

        public override string ToString()
        {
            return AudioPath;
        }
    }
}
