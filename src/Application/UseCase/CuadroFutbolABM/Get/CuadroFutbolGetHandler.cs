using Andreani.ARQ.Pipeline.Clases;
using CrudTest.Application.Common.Interfaces;
using CrudTest.Domain.Common;
using CrudTest.Domain.Dtos;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.Get
{
    public class CuadroFutbolGetHandler : IRequestHandler<CuadroFutbolGetRequest, Response<CuadroFutbolGetResponse>>
    {
        private readonly ICuadroFutbolServiceCommands Command;
        private readonly ICuadroFutbolServiceQueries Querie;
        public CuadroFutbolGetHandler(ICuadroFutbolServiceCommands cuadroFutbolServiceCommands, ICuadroFutbolServiceQueries cuadroFutbolServiceQueries)
        {
            Command = cuadroFutbolServiceCommands;
            Querie = cuadroFutbolServiceQueries;
        }
        public async Task<Response<CuadroFutbolGetResponse>> Handle(CuadroFutbolGetRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await Querie.GetAllAsync();
                if (list is not null)
                {
                    return new Response<CuadroFutbolGetResponse>
                    {
                        Content = new CuadroFutbolGetResponse
                        {
                            Message = "Success",
                            Lista = list.Select(q => new CuadroFutbolDTO { Id = q.Id, Nombre = q.Nombre }).ToList()
                        },
                        StatusCode = System.Net.HttpStatusCode.OK
                    };
                }
                else
                {
                    return new Response<CuadroFutbolGetResponse>
                    {
                        Content = new CuadroFutbolGetResponse
                        {
                            Message = ErrorMessage.NONEXISTENT_RECORDS,
                        },
                        StatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }
            }
            catch (Exception e)
            {
                return new Response<CuadroFutbolGetResponse>
                {
                    Content = new CuadroFutbolGetResponse
                    {
                        Message = e.ToString()
                    },
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
            }
        }
    }
}