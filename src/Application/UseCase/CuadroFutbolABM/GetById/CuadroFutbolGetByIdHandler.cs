using Andreani.ARQ.Pipeline.Clases;
using CrudTest.Application.Common.Interfaces;
using CrudTest.Domain.Common;
using CrudTest.Domain.Dtos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.GetById
{
    public class CuadroFutbolGetByIdHandler : IRequestHandler<CuadroFutbolGetByIdRequest, Response<CuadroFutbolGetByIdResponse>>
    {
        private readonly ICuadroFutbolServiceCommands Command;
        private readonly ICuadroFutbolServiceQueries Querie;
        public CuadroFutbolGetByIdHandler(ICuadroFutbolServiceCommands cuadroFutbolServiceCommands, ICuadroFutbolServiceQueries cuadroFutbolServiceQueries)
        {
            Command = cuadroFutbolServiceCommands;
            Querie = cuadroFutbolServiceQueries;
        }
        public async Task<Response<CuadroFutbolGetByIdResponse>> Handle(CuadroFutbolGetByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await Querie.GetByIdAsync("Id", request.Id);
                if (entity is not null)
                {
                    return new Response<CuadroFutbolGetByIdResponse>
                    {
                        Content = new CuadroFutbolGetByIdResponse
                        {
                            Message = "Success",
                            cuadroFutbolDTO = new CuadroFutbolDTO
                            {
                                Id = entity.Id,
                                Nombre = entity.Nombre,
                            }
                        },
                        StatusCode = System.Net.HttpStatusCode.OK
                    };
                }
                else
                {
                    return new Response<CuadroFutbolGetByIdResponse>
                    {
                        Content = new CuadroFutbolGetByIdResponse
                        {
                            Message = string.Format(ErrorMessage.NOT_STORED_RECORD, request.Id),
                        },
                        StatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }
            }
            catch (Exception e)
            {
                return new Response<CuadroFutbolGetByIdResponse>
                {
                    Content = new CuadroFutbolGetByIdResponse
                    {
                        Message = e.ToString()
                    },
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
            }
        }
    }
}