using GTSWebServiceMonitor.ViewModel;
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

        public ServiceViewModel ViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();
            this.ViewModel= new ServiceViewModel();
            this.BindingContext = ViewModel;
        }

    }
}
