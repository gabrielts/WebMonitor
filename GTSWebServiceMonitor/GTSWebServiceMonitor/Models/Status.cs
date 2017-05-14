using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTSWebServiceMonitor
{
    public enum Status
    {
        NotVerified,

        Verifying,

        Online,

        Warning,

        NoResponse,
    }
}
