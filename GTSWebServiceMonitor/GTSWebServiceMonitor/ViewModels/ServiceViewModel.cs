using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GTSWebServiceMonitor.ViewModel
{
    public class ServiceViewModel : BaseViewModel
    {

        public ObservableCollection<Service> Services { get; set; }
        public ICommand RefreshCommand { get; set; }

        public ServiceViewModel()
        {
            this.RefreshCommand = new Command(() =>
            {
                Refresh();
            }, () =>
            {
                return this.Services.Count > 0;
            });

            this.Services = new ObservableCollection<Service>()
            {
                //TODO Cadastro
                new Service { Description="CAMERA GARAGEM FRENTE", URL = "http://neuropsicotico.servebeer.com:8081" },
                new Service { Description="CAMERA GARAGEM ATRÁS", URL = "http://neuropsicotico.servebeer.com:8082" },
                new Service { Description="CAMERA LATERAL ATRÁS", URL = "http://neuropsicotico.servebeer.com:8083" },
                new Service { Description="ROTEADOR", URL = "http://192.168.16.1" }
            };
        }

        private void Refresh()
        {
            foreach (Service service in Services)
            {
                service.Refresh();
            }
        }

    }
}
