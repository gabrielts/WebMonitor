using GTSWebServiceMonitor.DB;
using GTSWebServiceMonitor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GTSWebServiceMonitor.ViewModels
{
    public class ServiceViewModel : BaseNotifyPropertyChanged, IDisposable
    {

        public ObservableCollection<Service> Services { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand AddCommand { get; set; }
        private Service selectedService;
        public Service SelectedService
        {
            get
            {
                return selectedService;
            }
            set
            {
                this.selectedService = value;
                if (value != null)
                    MessagingCenter.Send<Service>(value, Constants.SelectedServiceMessage);
            }
        }
        public ServiceViewModel()
        {
            this.Services = ServiceDataAccess.DataAccess.Services;
            this.RefreshCommand = new Command(() =>
            {
                Refresh();
            }, () =>
            {
                return this.Services.Count > 0;
            });

            this.AddCommand = new Command(() =>
            {
                MessagingCenter.Send<Service>(new Service(), Constants.AddServiceMessage);
            });

            MessagingCenter.Subscribe<Service>(this, Constants.AddServiceSuccessMessage, (service) =>
            {
                ReloadServices();
            });
            
            ReloadServices();
        }
        
        private void ReloadServices()
        {

        }

        private void Refresh()
        {
            foreach (Service service in Services)
            {
                service.Refresh();
            }
        }

        public void Dispose()
        {
            MessagingCenter.Unsubscribe<Service>(this, Constants.AddServiceSuccessMessage);
        }
    }
}
