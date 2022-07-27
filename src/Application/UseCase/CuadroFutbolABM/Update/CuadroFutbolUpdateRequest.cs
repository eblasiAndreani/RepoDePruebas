using Andreani.ARQ.Pipeline.Clases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.Update
{
    public class CuadroFutbolUpdateRequest : IRequest<Response<CuadroFutbolUpdateResponse>>
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
    }
}
