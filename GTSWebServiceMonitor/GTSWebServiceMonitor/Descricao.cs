using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTSWebServiceMonitor
{
    class Descricao : Attribute
    {

        public string Descr { get; set; }

        public Descricao(string descricao)
        {
            Descr = descricao;
        }

    }
}
