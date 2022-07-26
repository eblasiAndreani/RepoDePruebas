using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Domain.Entities
{
    public partial class CuadroFutbol
    {
        public CuadroFutbol()
        {
            Personas = new HashSet<Persona>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
