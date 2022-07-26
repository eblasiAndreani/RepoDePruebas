using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using CrudTest.Domain.Common;
using CrudTest.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.Delete
{
    public class CuadroFutbolDeleteHandler : IRequestHandler<CuadroFutbolDeleteRequest, Response<string>>
    {
        private readonly ITransactionalRepository _repository;
        private readonly IReadOnlyQuery _query;
        public CuadroFutbolDeleteHandler(ITransactionalRepository repository, IReadOnlyQuery query)
        {
            _repository = repository;
            _query = query;
        }
        public async Task<Response<string>> Handle(CuadroFutbolDeleteRequest request, CancellationToken cancellationToken)
        {
            var entity = await _query.GetByIdAsync<CuadroFutbol>("Id", request.Id);
            var response = new Response<string>();
            if (entity is null)
            {
                response.AddNotification("#3123", nameof(request.Id), string.Format(ErrorMessage.NOT_STORED_RECORD, request.Id));
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }
            _repository.Delete(entity);
            await _repository.SaveChangeAsync();
            response.Content = request.Id;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
    }
}

