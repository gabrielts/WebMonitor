using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GTSWebServiceMonitor
{
    public class Servico
    {
        public string Descricao { get; set; }
        public string URL { get; set; }
        public Situacao Situacao { get; set; } = Situacao.NaoVerificado;
        public Color Cor
        {
            get
            {
                if (Situacao == Situacao.Verificando) return Color.Orange;
                else if (Situacao == Situacao.Ativo) return Color.Green;
                else if (Situacao == Situacao.SemResposta) return Color.Tomato;
                return Color.Yellow;
            }
        }
        public void Atualizar(Action callback)
        {
            Situacao = Situacao.SemResposta;
            callback();
        }

    }
}
