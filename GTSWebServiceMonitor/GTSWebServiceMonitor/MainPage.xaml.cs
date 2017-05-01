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
        public List<Servico> Servicos { get; set; }

        public MainPage()
        {
            InitializeComponent();
            this.Servicos = new List<Servico>()
            {
                new Servico { Descricao="CAMERA GARAGEM FRENTE", URL = "http://neuropsicotico.servebeer.com:8081" },
                new Servico { Descricao="CAMERA GARAGEM ATRÁS", URL = "http://neuropsicotico.servebeer.com:8082" },
                new Servico { Descricao="CAMERA LATERAL ATRÁS", URL = "http://neuropsicotico.servebeer.com:8083" }
            };
            this.BindingContext = this;
            Device.StartTimer(new TimeSpan(0, 0, 5), () =>
            {
                foreach (Servico servico in Servicos)
                {
                    servico.Atualizar(() =>
                    {
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(servico.Cor));
                    });
                }
                return true;
            });
        }
    }
}
