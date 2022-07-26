using Andreani.ARQ.Pipeline.Clases;
using MediatR;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.GetById
{
    public class CuadroFutbolGetByIdRequest : IRequest<Response<CuadroFutbolGetByIdResponse>>
    {
        public string Id { get; set; }
    }
}
