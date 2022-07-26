using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using CrudTest.Application.Common.Interfaces;
using CrudTest.Domain.Common;
using CrudTest.Domain.Dtos;
using CrudTest.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.GetById
{
    public class CuadroFutbolGetByIdHandler : IRequestHandler<CuadroFutbolGetByIdRequest, Response<CuadroFutbolGetByIdResponse>>
    {
        private readonly ICuadroFutbolServiceQueries _query;
        public CuadroFutbolGetByIdHandler(ICuadroFutbolServiceQueries query)
        {
            _query = query;
        }
        public async Task<Response<CuadroFutbolGetByIdResponse>> Handle(CuadroFutbolGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = _query.GetByIdAsync("Nombre", "''Boca Juniors' or '1=1''");
            var response = new Response<CuadroFutbolGetByIdResponse>();
            if (entity is null)
            {
                response.Content = new CuadroFutbolGetByIdResponse() { Message = string.Format(ErrorMessage.NOT_STORED_RECORD, request.Id) };
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }

            response.Content = new CuadroFutbolGetByIdResponse() { Message = "Ok", cuadroFutbolDTO = new CuadroFutbolDTO(){ Id = entity.Id, Nombre = entity.Result.Nombre } };
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
    }
}

