using GTSWebServiceMonitor.Models;
using ModernHttpClient;
using SQLite;
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
    public class Service : BaseNotifyPropertyChanged
    {

        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
                OnPropertyChanged();
            }
        }

        private string description;
        [NotNull]
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
                OnPropertyChanged();
            }
        }

        private string url;
        [NotNull]
        public string URL
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                OnPropertyChanged();
            }
        }

        private Status status;
        [Ignore]
        public Status Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                OnPropertyChanged();
                if (Status == Status.Verifying) this.Color = Color.Yellow;
                else if (Status == Status.Online) this.Color = Color.Green;
                else if (Status == Status.Warning) this.Color = Color.Tomato;
                else if (Status == Status.NoResponse) this.Color = Color.Red;
                else this.Color = Color.Orange;
            }
        }

        private Color color;
        [Ignore]
        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
                OnPropertyChanged();
            }
        }

        private bool refreshing;
        [Ignore]
        public bool Refreshing
        {
            get
            {
                return this.refreshing;
            }
            set
            {
                this.refreshing = value;
                OnPropertyChanged();
            }
        }

        public async void Refresh()
        {
            try
            {
                Refreshing = true;
                Status = Status.Verifying;
                var httpClient = new HttpClient(new NativeMessageHandler())
                {
                    //Todo configuration
                    Timeout = new TimeSpan(0, 0, 7)
                };
                HttpResponseMessage response = await httpClient.GetAsync(URL);
                if (response.IsSuccessStatusCode) Status = Status.Online;
                else Status = Status.Warning;
            }
            catch (Exception ex)
            {
                Status = Status.NoResponse;
            }
            finally
            {
                Refreshing = false;
            }
        }

    }
}
