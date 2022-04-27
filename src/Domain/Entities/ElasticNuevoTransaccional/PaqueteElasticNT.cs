using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo.Domain.Entities.ElasticNuevoTransaccional
{
    public class PaqueteElasticNT
    {
        public string Id { get; set; }
        public string TipoId { get; set; }
        public string Medidas { get; set; }
        public string ValorDeclarado { get; set; }
        public string Tipo { get; set; }
    }
}
