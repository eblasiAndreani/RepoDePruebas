using Andreani.ARQ.Pipeline.Clases;
using CrudTest.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.Create
{
    public class CuadroFutbolCreateHandler : IRequestHandler<CuadroFutbolCreateRequest, Response<CuadroFutbolCreateResponse>>
    {
        private readonly ICuadroFutbolServiceCommands cuadroFutbolServiceCommands;
        public CuadroFutbolCreateHandler(ICuadroFutbolServiceCommands _cuadroFutbolServiceCommands)
        {
            cuadroFutbolServiceCommands = _cuadroFutbolServiceCommands;
        }
        public Task<Response<CuadroFutbolCreateResponse>> Handle(CuadroFutbolCreateRequest request, CancellationToken cancellationToken)
        {
            var entity = cuadroFutbolServiceCommands.Create(request);
            return Task.FromResult(new Response<CuadroFutbolCreateResponse>
            {
                Content = new CuadroFutbolCreateResponse
                {
                    Message = "Success",
                    CuadroId = entity.Id,
                    CuadroNombre = request.nombre
                },
                StatusCode = System.Net.HttpStatusCode.Created
            });
        }
    }
}
