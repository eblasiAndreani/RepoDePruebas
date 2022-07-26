using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Domain.Entities
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Dni { get; set; }
        public int? IdCuadro { get; set; }

        public virtual CuadroFutbol IdCuadroNavigation { get; set; }
    }
}
