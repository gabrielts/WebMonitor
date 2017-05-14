using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GTSWebServiceMonitor
{
    public class Veiculo
    {
        [JsonProperty(PropertyName = "SetupFee")]
        public string nome { get; set; }
    }
}
