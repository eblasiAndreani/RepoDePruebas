using Andreani.ARQ.Pipeline.Clases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.Get
{
    public class CuadroFutbolGetRequest : IRequest<Response<CuadroFutbolGetResponse>> {  }
}
