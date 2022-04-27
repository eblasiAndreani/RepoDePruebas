using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo.Domain.Entities.ElasticNuevoTransaccional
{
    public class EnvioElasticNT
    {
        public string Id { get; set; }
        public string TipoDeEnvio { get; set; }
        public string NumeroDeSeguimiento { get; set; }
        public string NumeroDeContrato { get; set; }
        public string Estado { get; set; }
        public string FechaCreacion { get; set; }
        public DomicilioElasticNT Origen { get; set; }
        public DomicilioElasticNT Destino { get; set; }
        public PersonaElasticNT Remitente { get; set; }
        public PersonaElasticNT Destinatario { get; set; }
        public List<PaqueteElasticNT> Paquetes { get; set; }
    }
}
