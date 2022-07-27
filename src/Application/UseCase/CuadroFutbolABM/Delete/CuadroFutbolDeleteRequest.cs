using Andreani.ARQ.Pipeline.Clases;
using MediatR;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.Delete
{
    public class CuadroFutbolDeleteRequest : IRequest<Response<CuadroFutbolDeleteResponse>>
    {
        public string Id { get; set; }
    }
}
