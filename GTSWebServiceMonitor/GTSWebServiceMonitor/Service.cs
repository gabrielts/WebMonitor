using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public void Refresh(Action callback)
        {
            //TODO Test if online
            Status = Status.NoResponse;
            callback();
        }

    }
}
