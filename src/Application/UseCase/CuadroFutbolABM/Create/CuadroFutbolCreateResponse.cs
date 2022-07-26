using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.Create
{
    public class CuadroFutbolCreateResponse
    {
        public string Message { get; set; }
        public int CuadroId { get; set; }
        public string CuadroNombre { get; set; }
    }
}
