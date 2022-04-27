using Andreani.ARQ.Pipeline.Clases;
using Ejemplo.Domain.Entities.ElasticNuevoTransaccional;
using Elasticsearch.Net;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejemplo.Application.UseCase.V1
{
    public class PruebaHandler : IRequestHandler<PruebaRequest, Response<PruebaResponse>>
    {
        private readonly IElasticLowLevelClient elasticLowLevelClient;

        public PruebaHandler(IElasticLowLevelClient elasticLowLevelClient)
        {
            this.elasticLowLevelClient = elasticLowLevelClient;
        }
        public async Task<Response<PruebaResponse>> Handle(PruebaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var pedido = createNewPedidoElastic();

                var response = await elasticLowLevelClient.IndexAsync<StringResponse>("new_transaccional_01", Convert.ToString(pedido.PedidoId), PostData.Serializable(pedido));

                return new Response<PruebaResponse>();
            }
            catch (Exception)
            {
                return new Response<PruebaResponse>
                {
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
        }
        public PedidoElasticNT createNewPedidoElastic()
        {
            var pedido = new PedidoElasticNT
            {
                PedidoId = "12345",
                UsuarioId = "UsuarioId",
                UsuarioLoginId = "UsuarioLoginId",
                Estado = "Transporte",
                Envios = new List<EnvioElasticNT>
                {
                    new EnvioElasticNT
                    {
                        Id = "IdEnvio",
                        TipoDeEnvio = "Internacional",
                        NumeroDeSeguimiento = "NumeroDeSeguimiento",
                        NumeroDeContrato = "NumeroDeContrato",
                        Estado = "Transporte",
                        FechaCreacion = Convert.ToString(DateTime.Now),
                        Origen = new DomicilioElasticNT
                        {
                            Direccion = "Aconquija N° 2345 entre Ruiz Dias de Guzman y Alta Gracia",
                            Tipo = "Local"
                        },
                        Destino = new DomicilioElasticNT
                        {
                            Direccion = "Calingasta al lado del Gauchito de gil",
                            Tipo = "Domicilio"
                        },
                        Remitente = new PersonaElasticNT
                        {
                            Apellido = "Francella",
                            Nombre = "Guillermo",
                            Dni = "otroDni",
                            Email = "francella@gmail.com",
                            Telefono = "113165432733"
                        },
                        Destinatario = new PersonaElasticNT
                        {
                            Apellido = "Stallone",
                            Nombre = "Silvester",
                            Dni = "dniDeSilvester",
                            Email = "stalolona@gmail.com",
                            Telefono = "14666457678789"
                        },
                        Paquetes = new List<PaqueteElasticNT>
                        {
                            new PaqueteElasticNT
                            {
                                Id = "IdPaquete",
                                TipoId = "TipoIdPaquete",
                                Medidas = "Muy grande",
                                ValorDeclarado = "9999",
                                Tipo = "Damian"
                            }
                        }
                    }
                }
            };
            return pedido;
        }
    }
}


