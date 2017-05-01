using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GTSWebServiceMonitor
{
    public class Service
    {
        public string Description { get; set; }
        public string URL { get; set; }
        public Status Status { get; set; } = Status.NotVerified;
        public Color Color
        {
            get
            {
                if (Status == Status.Verifying) return Color.Orange;
                else if (Status == Status.Online) return Color.Green;
                else if (Status == Status.NoResponse) return Color.Tomato;
                return Color.Yellow;
            }
        }
        public void Refresh(Action updateStatus)
        {
            Task t = new Task(() =>
            {
                try
                {
                    Status = Status.Verifying;
                    updateStatus();
                    var httpClient = new HttpClient(new NativeMessageHandler());
                    httpClient.Timeout = new TimeSpan(0, 0, 1);
                    HttpResponseMessage response = httpClient.GetAsync(URL).Result;
                    Status = Status.Online;
                }
                catch
                {
                    Status = Status.NoResponse;
                }
                updateStatus();
            });
            t.Start();
        }

    }
}
