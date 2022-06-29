// Decompiled with JetBrains decompiler
// Type: TrackingSync.RespuestaConverter
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
  public class RespuestaConverter : ITypeConverter<TrackingSync.Model.Respuesta, TrackingSync.Model.Elastic.Respuesta>
  {
    public TrackingSync.Model.Elastic.Respuesta Convert(
      TrackingSync.Model.Respuesta source,
      TrackingSync.Model.Elastic.Respuesta destination,
      ResolutionContext context)
    {
      destination = new TrackingSync.Model.Elastic.Respuesta()
      {
        Fecha = source.Fecha,
        Comentario = source.Comentario,
        RespuestaTraducida = Cache.Instance.Resolver<TraduccionRespuesta>("TraduccionesRespuesta").FirstOrDefault<TraduccionRespuesta>((Func<TraduccionRespuesta, bool>) (p => p.Respuesta == source.RespuestaEnum))?.Traduccion
      };
      return destination;
    }
  }
}
