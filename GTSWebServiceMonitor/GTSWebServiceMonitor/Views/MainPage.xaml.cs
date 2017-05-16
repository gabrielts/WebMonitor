using GTSWebServiceMonitor.Models;
using GTSWebServiceMonitor.ViewModels;
using GTSWebServiceMonitor.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GTSWebServiceMonitor.Views
{

    public partial class MainPage : ContentPage
    {

        public ServiceViewModel ViewModel { get; set; }
        
        public MainPage()
        {
            InitializeComponent();
            this.ViewModel= new ServiceViewModel();
            this.BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Service>(this, Constants.AddServiceMessage, (service) =>
            {
                Navigation.PushAsync(new ServiceRegistration(service));
            });
            MessagingCenter.Subscribe<Service>(this, Constants.SelectedServiceMessage, (service) =>
            {
                Navigation.PushAsync(new ServiceRegistration(service));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Service>(this, Constants.AddServiceMessage);
            MessagingCenter.Unsubscribe<Service>(this, Constants.SelectedServiceMessage);
        }

    }
}
