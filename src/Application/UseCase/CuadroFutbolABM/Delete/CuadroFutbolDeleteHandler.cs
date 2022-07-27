using Andreani.ARQ.Pipeline.Clases;
using CrudTest.Application.Common.Interfaces;
using CrudTest.Domain.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.Delete
{
    public class CuadroFutbolDeleteHandler : IRequestHandler<CuadroFutbolDeleteRequest, Response<CuadroFutbolDeleteResponse>>
    {
        private readonly ICuadroFutbolServiceCommands Command;
        private readonly ICuadroFutbolServiceQueries Querie;
        public CuadroFutbolDeleteHandler(ICuadroFutbolServiceCommands cuadroFutbolServiceCommands, ICuadroFutbolServiceQueries cuadroFutbolServiceQueries)
        {
            Command = cuadroFutbolServiceCommands;
            Querie = cuadroFutbolServiceQueries;
        }
        public async Task<Response<CuadroFutbolDeleteResponse>> Handle(CuadroFutbolDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await Querie.GetByIdAsync("Id", request.Id);
                if (entity is not null)
                {
                    await Command.Delete(entity);
                    return new Response<CuadroFutbolDeleteResponse>
                    {
                        Content = new CuadroFutbolDeleteResponse
                        {
                            Message = "Success",
                            CuadroId = entity.Id,
                            CuadroNombre = entity.Nombre
                        },
                        StatusCode = System.Net.HttpStatusCode.Created
                    };
                }
                else
                {
                    return new Response<CuadroFutbolDeleteResponse>
                    {
                        Content = new CuadroFutbolDeleteResponse
                        {
                            Message = string.Format(ErrorMessage.NOT_STORED_RECORD, request.Id),
                        },
                        StatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }
            }
            catch (Exception e)
            {
                return new Response<CuadroFutbolDeleteResponse>
                {
                    Content = new CuadroFutbolDeleteResponse
                    {
                        Message = e.ToString()
                    },
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
            }
        }
    }
}