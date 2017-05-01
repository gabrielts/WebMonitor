using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GTSWebServiceMonitor
{

    public partial class MainPage : ContentPage
    {

        public string Texto { get; set; }
        public List<Service> Services { get; set; }

        public MainPage()
        {
            InitializeComponent();
            this.Services = new List<Service>()
            {
                new Service { Description="CAMERA GARAGEM FRENTE", URL = "http://neuropsicotico.servebeer.com:8081" },
                new Service { Description="CAMERA GARAGEM ATRÁS", URL = "http://neuropsicotico.servebeer.com:8082" },
                new Service { Description="CAMERA LATERAL ATRÁS", URL = "http://neuropsicotico.servebeer.com:8083" }
            };
            this.BindingContext = this;
            Device.StartTimer(new TimeSpan(0, 0, 10), () =>
             {
                 Refresh();
                 return true;
             });
        }

        private void Refresh()
        {
            foreach (Service service in Services)
            {
                service.Refresh(() =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(service.Color));
                    });
                });
            }
        }
    }
}
