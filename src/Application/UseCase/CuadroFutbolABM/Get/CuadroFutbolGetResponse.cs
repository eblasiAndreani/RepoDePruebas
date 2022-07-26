using CrudTest.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.Get
{
    public class CuadroFutbolGetResponse
    {
        public List<CuadroFutbolDTO> Lista { get; set; }
        public string Message { get; set; }
    }
}
