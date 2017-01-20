using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angkor.O7Web.Common.Finantial.Entity
{
    public class InvoiceType
    {
        public string TipoDocumento { get; set; }
        public string SerieExterno { get; set; }
        public string FechaDocumento { get; set; }
        public string FechaVencimiento { get; set; }
        public string TipoMoneda { get; set; }

    }
}
