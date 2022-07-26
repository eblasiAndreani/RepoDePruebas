using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using CrudTest.Domain.Common;
using CrudTest.Domain.Dtos;
using CrudTest.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.Get
{
    public class CuadroFutbolGetHandler : IRequestHandler<CuadroFutbolGetRequest, Response<CuadroFutbolGetResponse>>
    {
        private readonly IReadOnlyQuery _query;
        public CuadroFutbolGetHandler(IReadOnlyQuery query)
        {
            _query = query;
        }
        public async Task<Response<CuadroFutbolGetResponse>> Handle(CuadroFutbolGetRequest request, CancellationToken cancellationToken)
        {
            var list = await _query.GetAllAsync<CuadroFutbol>();
            var response = new Response<CuadroFutbolGetResponse>();
            if (list is null)
            {
                response.Content = new CuadroFutbolGetResponse(){ Message = ErrorMessage.NONEXISTENT_RECORDS };
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }

            response.Content = new CuadroFutbolGetResponse() { Message = "Ok", Lista = list.Select(q => new CuadroFutbolDTO { Id = q.Id , Nombre=q.Nombre }).ToList() };
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
    }
}

