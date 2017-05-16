using GTSWebServiceMonitor.Models;
using GTSWebServiceMonitor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTSWebServiceMonitor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiceRegistration : ContentPage
    {

        public ServiceRegistration(Service service)
        {
            InitializeComponent();
            this.BindingContext = new ServiceRegistrationViewModel(service);            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Service>(this, Constants.AddServiceSuccessMessage, (service) =>
            {
                DisplayAlert("Success", String.Format("Service {0} saved successfully", service.Description), "OK").ContinueWith((result) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Navigation.PopAsync();
                    });
                });                
            });
            MessagingCenter.Subscribe<Service>(this, Constants.AddServiceErrorMessage, (service) =>
            {
                DisplayAlert("Error", String.Format("Ops... An error has ocurred on save service {0} :(, try again later...", service.Description), "OK");
            });
            MessagingCenter.Subscribe<Service>(this, Constants.RemoveServiceSuccessMessage, (service) =>
            {
                DisplayAlert("Success", String.Format("Service {0} removed successfully", service.Description), "OK").ContinueWith((result) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Navigation.PopAsync();
                    });
                });
            });
            MessagingCenter.Subscribe<Service>(this, Constants.RemoveServiceErrorMessage, (service) =>
            {
                DisplayAlert("Error", String.Format("Ops... An error has ocurred on remove service {0} :(, try again later...", service.Description), "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Service>(this, Constants.AddServiceSuccessMessage);
            MessagingCenter.Unsubscribe<Service>(this, Constants.AddServiceErrorMessage);
            MessagingCenter.Unsubscribe<Service>(this, Constants.RemoveServiceSuccessMessage);
            MessagingCenter.Unsubscribe<Service>(this, Constants.RemoveServiceErrorMessage);
        }

    }
}
