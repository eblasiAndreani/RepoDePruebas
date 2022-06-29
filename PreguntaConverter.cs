// Decompiled with JetBrains decompiler
// Type: TrackingSync.PreguntaConverter
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using AutoMapper;
using System;
using System.Linq;
using TrackingSync.Helper;
using TrackingSync.Model;

namespace TrackingSync
{
  public class PreguntaConverter : ITypeConverter<TrackingSync.Model.Pregunta, TrackingSync.Model.Elastic.Pregunta>
  {
    public TrackingSync.Model.Elastic.Pregunta Convert(
      TrackingSync.Model.Pregunta source,
      TrackingSync.Model.Elastic.Pregunta destination,
      ResolutionContext context)
    {
      destination = new TrackingSync.Model.Elastic.Pregunta()
      {
        Fecha = source.Fecha,
        Abierta = source.Abierta,
        EsParaCliente = source.EsParaCliente,
        Id = source.Id,
        ProcesandoRespuesta = source.ProcesandoRespuesta,
        URlRespuesta = source.URLRespuestas,
        Respuesta = Mapper.Map<TrackingSync.Model.Elastic.Respuesta[]>((object) source.Respuestas),
        PreguntaTraducida = Cache.Instance.Resolver<TraduccionPregunta>("TraduccionesPregunta").FirstOrDefault<TraduccionPregunta>((Func<TraduccionPregunta, bool>) (p => p.Pregunta == source.PreguntaEnum))?.Traduccion
      };
      return destination;
    }
  }
}
