// Decompiled with JetBrains decompiler
// Type: TrackingSync.Converters.TrackingConverter
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TrackingSync.Helper;
using TrackingSync.Model;
using TrackingSync.Model.Elastic;

namespace TrackingSync.Converters
{
  public class TrackingConverter : ITypeConverter<TrackingSync.Model.Tracking, TrackingSync.Model.Elastic.Tracking>
  {
    public TrackingSync.Model.Elastic.Tracking Convert(
      TrackingSync.Model.Tracking source,
      TrackingSync.Model.Elastic.Tracking destination,
      ResolutionContext context)
    {
      MapSync mapSync = new MapSync();
      string valor1 = source.DatosAdicionales.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals("Origen"))).FirstOrDefault<DatosAdicionales>()?.Valor;
      string valor2 = source.DatosAdicionales.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals("Destino"))).FirstOrDefault<DatosAdicionales>()?.Valor;
      string valor3 = source.DatosAdicionales.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals("DestinoAnterior"))).FirstOrDefault<DatosAdicionales>()?.Valor;
      string valor4 = source.DatosAdicionales.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals("Remitente"))).FirstOrDefault<DatosAdicionales>()?.Valor;
      string valor5 = source.DatosAdicionales.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals("Destinatario"))).FirstOrDefault<DatosAdicionales>()?.Valor;
      string valor6 = source.DatosAdicionales.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals("UsuarioAsociado"))).FirstOrDefault<DatosAdicionales>()?.Valor;
      string str = source.Estado?.ToString();
      IOrderedEnumerable<TrackingSync.Model.Referencia> source1 = source.Referencias.Where<TrackingSync.Model.Referencia>((Func<TrackingSync.Model.Referencia, bool>) (r => r.Nombre.Equals("NumeroDeEnvio") || r.Nombre.Equals("NumeroDePedido"))).OrderBy<TrackingSync.Model.Referencia, string>((Func<TrackingSync.Model.Referencia, string>) (r => r.Nombre));
      List<TrackingSync.Model.Elastic.GestionCobranza> gestionCobranza = new List<TrackingSync.Model.Elastic.GestionCobranza>();
      source.GestionCobranza.ToList<TrackingSync.Model.GestionCobranza>().ForEach((Action<TrackingSync.Model.GestionCobranza>) (gc => gestionCobranza.Add(new TrackingSync.Model.Elastic.GestionCobranza(gc))));
      IList<TraduccionEstado> source2 = mapSync.MapEstados(source);
      TrackingSync.Model.Elastic.Tracking tracking1 = new TrackingSync.Model.Elastic.Tracking();
      tracking1.NumeroAndreani = source1.FirstOrDefault<TrackingSync.Model.Referencia>()?.Valor;
      tracking1.ReferenciaPrincipal = source.Referencias.FirstOrDefault<TrackingSync.Model.Referencia>((Func<TrackingSync.Model.Referencia, bool>) (r => r.Nombre.Equals("ReferenciaPrincipal")))?.Valor;
      tracking1.ReferenciaCliente = source.Referencias.FirstOrDefault<TrackingSync.Model.Referencia>((Func<TrackingSync.Model.Referencia, bool>) (r => r.Codigo.Equals("NumeroDeSeguimientoDelCliente")))?.Valor;
      TrackingSync.Model.Elastic.Tracking tracking2 = tracking1;
      DateTime? nullable1 = source.FechaAlta;
      DateTime valueOrDefault1 = nullable1.GetValueOrDefault();
      tracking2.FechaAlta = valueOrDefault1;
      tracking1.Estado = str;
      tracking1.Servicio = source.DatosAdicionales.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals("TipoDeServicio"))).FirstOrDefault<DatosAdicionales>()?.Valor;
      tracking1.Pedido = source.DatosAdicionales.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals("TipoPedido"))).FirstOrDefault<DatosAdicionales>()?.Valor;
      TrackingSync.Model.Elastic.Tracking tracking3 = tracking1;
      nullable1 = source.FechaPrimeraNovedad;
      DateTime valueOrDefault2 = nullable1.GetValueOrDefault();
      tracking3.FechaPrimeraNovedad = valueOrDefault2;
      TrackingSync.Model.Elastic.Tracking tracking4 = tracking1;
      nullable1 = source.FechaUltimaNovedad;
      DateTime valueOrDefault3 = nullable1.GetValueOrDefault();
      tracking4.FechaUltimaNovedad = valueOrDefault3;
      tracking1.Multimedias = Mapper.Map<TrackingSync.Model.Elastic.Multimedia[]>((object) source.Multimedias);
      tracking1.Referencias = source.Referencias.Select<TrackingSync.Model.Referencia, string>((Func<TrackingSync.Model.Referencia, string>) (r => r.Valor)).ToArray<string>();
      tracking1.Origen = new Lugar(valor1, false);
      tracking1.Destino = new Lugar(valor2, false);
      tracking1.DestinoAnterior = new Lugar(valor3, false);
      tracking1.Remitente = new DatosPersonales(valor4);
      tracking1.Destinatario = new DatosPersonales(valor5);
      tracking1.CodigoContrato = source.Contrato?.Codigo;
      tracking1.CodigoCliente = source.Contrato.Cliente?.Codigo;
      tracking1.Novedades = Mapper.Map<TrackingSync.Model.Elastic.Novedad[]>((object) source.Novedades.OrderByDescending<TrackingSync.Model.Novedad, DateTime>((Func<TrackingSync.Model.Novedad, DateTime>) (n => n.Fecha)).ThenByDescending<TrackingSync.Model.Novedad, string>((Func<TrackingSync.Model.Novedad, string>) (n => n.NumeroOrden)).ToArray<TrackingSync.Model.Novedad>());
      tracking1.Traducciones = Mapper.Map<Traduccion[]>((object) source.Traducciones);
      tracking1.PreguntasAbiertas = source.Preguntas.Any<TrackingSync.Model.Pregunta>((Func<TrackingSync.Model.Pregunta, bool>) (x => x.Abierta));
      tracking1.Estados = Mapper.Map<Estado[]>((object) source2);
      TrackingSync.Model.Elastic.Tracking tracking5 = tracking1;
      DateTime result;
      DateTime? nullable2;
      if (!DateTime.TryParse(source.DatosAdicionales.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals("FechaRetiro"))).FirstOrDefault<DatosAdicionales>()?.Valor, out result))
      {
        nullable1 = new DateTime?();
        nullable2 = nullable1;
      }
      else
        nullable2 = new DateTime?(result);
      tracking5.FechaRetiro = nullable2;
      TrackingSync.Model.Elastic.Tracking tracking6 = tracking1;
      string[] strArray;
      if (valor6 != null)
        strArray = Mapper.Map<string[]>((object) valor6.Split(';'));
      else
        strArray = (string[]) null;
      tracking6.UsuariosAsociados = strArray;
      tracking1.DatosPODIR = source2.FirstOrDefault<TraduccionEstado>()?.EstadoDetallado == "RENDIDO" ? source.DatosAdicionales.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals("POD_IR"))).FirstOrDefault<DatosAdicionales>()?.Valor : "";
      tracking1.DatosPOD = source2.FirstOrDefault<TraduccionEstado>()?.EstadoResumido == "ENTREGADO" ? source.DatosAdicionales.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals("POD"))).FirstOrDefault<DatosAdicionales>()?.Valor : "";
      tracking1.DatosGEO = source2.FirstOrDefault<TraduccionEstado>()?.EstadoResumido == "ENTREGADO" ? source.DatosAdicionales.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals("GEO"))).FirstOrDefault<DatosAdicionales>()?.Valor : "";
      tracking1.GestionCobranza = Mapper.Map<TrackingSync.Model.Elastic.GestionCobranza[]>((object) gestionCobranza);
      tracking1.Export = new Export(source);
      tracking1.Pregunta = Mapper.Map<TrackingSync.Model.Elastic.Pregunta[]>((object) source.Preguntas);
      tracking1.AltaPorDevolucionNumeroEnvio = source.Referencias.FirstOrDefault<TrackingSync.Model.Referencia>((Func<TrackingSync.Model.Referencia, bool>) (r => r.Nombre.Equals("AltaPorDevolucionNumeroEnvio")))?.Valor;
      tracking1.AltaPorRecanalizacionNumeroEnvio = source.Referencias.FirstOrDefault<TrackingSync.Model.Referencia>((Func<TrackingSync.Model.Referencia, bool>) (r => r.Nombre.Equals("AltaPorRecanalizacionNumeroEnvio")))?.Valor;
      tracking1.DevueltoPorNumeroEnvio = source.Referencias.FirstOrDefault<TrackingSync.Model.Referencia>((Func<TrackingSync.Model.Referencia, bool>) (r => r.Nombre.Equals("DevueltoPorNumeroEnvio")))?.Valor;
      tracking1.RecanalizadoPorNumeroEnvio = source.Referencias.FirstOrDefault<TrackingSync.Model.Referencia>((Func<TrackingSync.Model.Referencia, bool>) (r => r.Nombre.Equals("RecanalizadoPorNumeroEnvio")))?.Valor;
      destination = tracking1;
      return destination;
    }
  }
}
