using Andreani.ARQ.Pipeline.Clases;
using CrudTest.Application.Common.Interfaces;
using CrudTest.Domain.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTest.Application.UseCase.CuadroFutbolABM.Update
{
    public class CuadroFutbolUpdateHandler
    {
        private readonly ICuadroFutbolServiceCommands Command;
        private readonly ICuadroFutbolServiceQueries Querie;
        public CuadroFutbolUpdateHandler(ICuadroFutbolServiceCommands cuadroFutbolServiceCommands, ICuadroFutbolServiceQueries cuadroFutbolServiceQueries)
        {
            Command = cuadroFutbolServiceCommands;
            Querie = cuadroFutbolServiceQueries;
        }
        public async Task<Response<CuadroFutbolUpdateResponse>> Handle(CuadroFutbolUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await Querie.GetByIdAsync("Id", request.Id);
                if (entity is not null)
                {
                    entity.Nombre = request.Nombre;
                    await Command.Delete(entity);
                    return new Response<CuadroFutbolUpdateResponse>
                    {
                        Content = new CuadroFutbolUpdateResponse
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
                    return new Response<CuadroFutbolUpdateResponse>
                    {
                        Content = new CuadroFutbolUpdateResponse
                        {
                            Message = string.Format(ErrorMessage.NOT_STORED_RECORD, entity.Nombre),
                        },
                        StatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }
            }
            catch (Exception e)
            {
                return new Response<CuadroFutbolUpdateResponse>
                {
                    Content = new CuadroFutbolUpdateResponse
                    {
                        Message = e.ToString()
                    },
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
            }
        }
    }
}
