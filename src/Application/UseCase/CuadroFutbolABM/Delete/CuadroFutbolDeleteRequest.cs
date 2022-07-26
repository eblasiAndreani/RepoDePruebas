using Andreani.ARQ.Pipeline.Clases;
using MediatR;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.Delete
{
    public class CuadroFutbolDeleteRequest : IRequest<Response<string>>
    {
        public string Id { get; set; }
    }
}
