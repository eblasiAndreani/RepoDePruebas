using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo.Domain.Entities.ElasticNuevoTransaccional
{
    public class PedidoElasticNT
    {
        public string PedidoId { get; set; }
        public string UsuarioId { get; set; }
        public string UsuarioLoginId { get; set; }
        public string Estado { get; set; }
        public List<EnvioElasticNT> Envios { get; set; }
    }
}
