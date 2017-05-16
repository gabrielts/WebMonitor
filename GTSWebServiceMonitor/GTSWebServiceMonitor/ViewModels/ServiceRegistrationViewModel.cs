using GTSWebServiceMonitor.DB;
using GTSWebServiceMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GTSWebServiceMonitor.ViewModels
{
    public class ServiceRegistrationViewModel
    {

        public ICommand SaveCommand { get; set; }
        public ICommand RemoveCommand { get; set; }

        public Service Service { get; set; }

        public ServiceRegistrationViewModel(Service service)
        {
            this.Service = service;
            
            SaveCommand = new Command(() =>
            {
                try
                {
                    ServiceDataAccess.DataAccess.SaveService(service);
                    MessagingCenter.Send<Service>(service, Constants.AddServiceSuccessMessage);
                } catch
                {
                    MessagingCenter.Send<Service>(service, Constants.AddServiceErrorMessage);
                }                
            });
            RemoveCommand = new Command(() =>
            {
                try
                {
                    ServiceDataAccess.DataAccess.DeleteService(service);
                    MessagingCenter.Send<Service>(service, Constants.RemoveServiceSuccessMessage);
                }
                catch
                {
                    MessagingCenter.Send<Service>(service, Constants.RemoveServiceErrorMessage);
                }
            },() =>
            {
                return service.Id != 0;
            });
        }
        
    }
}
