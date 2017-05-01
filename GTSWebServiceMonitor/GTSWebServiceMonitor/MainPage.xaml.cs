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
                new Service { Description="CAMERA LATERAL ATRÁS", URL = "http://neuropsicotico.servebeer.com:8083" },
                new Service { Description="ROTEADOR", URL = "http://192.168.16.1" }
            };
            this.BindingContext = this;
        }

        private void Refresh()
        {
            foreach (Service service in Services)
            {
                service.Refresh();
            }
        }

        private void btnRefresh_Clicked(object sender, EventArgs e)
        {
           Refresh();
        }
    }
}
