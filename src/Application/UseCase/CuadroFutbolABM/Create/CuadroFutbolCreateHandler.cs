using Andreani.ARQ.Pipeline.Clases;
using CrudTest.Application.Common.Interfaces;
using CrudTest.Domain.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.Create
{
    public class CuadroFutbolCreateHandler : IRequestHandler<CuadroFutbolCreateRequest, Response<CuadroFutbolCreateResponse>>
    {
        private readonly ICuadroFutbolServiceCommands Command;
        private readonly ICuadroFutbolServiceQueries Querie;
        public CuadroFutbolCreateHandler(ICuadroFutbolServiceCommands cuadroFutbolServiceCommands, ICuadroFutbolServiceQueries cuadroFutbolServiceQueries)
        {
            Command = cuadroFutbolServiceCommands;
            Querie = cuadroFutbolServiceQueries;
        }
        public async Task<Response<CuadroFutbolCreateResponse>> Handle(CuadroFutbolCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await Querie.GetByIdAsync("Nombre",request.Nombre);
                if(entity is null)
                {
                    await Command.Create(request);
                    return new Response<CuadroFutbolCreateResponse>
                    {
                        Content = new CuadroFutbolCreateResponse
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
                    return new Response<CuadroFutbolCreateResponse>
                    {
                        Content = new CuadroFutbolCreateResponse
                        {
                            Message = string.Format(ErrorMessage.STORED_RECORD, request.Nombre),
                        },
                        StatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }
            }
            catch (Exception e)
            {
                return new Response<CuadroFutbolCreateResponse>
                {
                    Content = new CuadroFutbolCreateResponse
                    {
                        Message = e.ToString()
                    },
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
            }
        }
    }
}
