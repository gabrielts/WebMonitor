using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTSWebServiceMonitor
{
    public enum Situacao
    {
        [Descricao("Não Verificado")]
        NaoVerificado,

        [Descricao("Verificando")]
        Verificando,

        [Descricao("Ativo")]
        Ativo,

        [Descricao("Sem Resposta")]
        SemResposta,
    }
}
