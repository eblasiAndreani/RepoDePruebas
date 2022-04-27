using Andreani.ARQ.Pipeline.Clases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo.Application.UseCase.V1
{
    public class PruebaRequest : IRequest<Response<PruebaResponse>>
    {
    }
}
