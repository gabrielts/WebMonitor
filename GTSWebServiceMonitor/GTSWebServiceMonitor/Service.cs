using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GTSWebServiceMonitor
{
    public class Service : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public string Description { get; set; }
        public string URL { get; set; }
        private Status status;
        public Status Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                PropertyChanged.Invoke(Status, new PropertyChangedEventArgs(nameof(Color)));
            }
        }
        public Color Color
        {
            get
            {
                if (Status == Status.Verifying) return Color.Yellow;
                else if (Status == Status.Online) return Color.Green;
                else if (Status == Status.Warning) return Color.Tomato;
                else if (Status == Status.NoResponse) return Color.Red;
                return Color.Orange;
            }
        }

        public void Refresh()
        {
            Task.Run(() =>
            {
                try
                {
                    Status = Status.Verifying;
                    var httpClient = new HttpClient(new NativeMessageHandler());
                    httpClient.Timeout = new TimeSpan(0, 0, 1);
                    HttpResponseMessage response = httpClient.GetAsync(URL).Result;
                    if (response.IsSuccessStatusCode) Status = Status.Online;
                    else Status = Status.Warning;
                }
                catch
                {
                    Status = Status.NoResponse;
                }
            });
        }

    }
}
