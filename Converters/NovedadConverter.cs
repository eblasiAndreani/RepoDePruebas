// Decompiled with JetBrains decompiler
// Type: TrackingSync.Converters.NovedadConverter
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TrackingSync.Model;

namespace TrackingSync.Converters
{
  public class NovedadConverter : ITypeConverter<TrackingSync.Model.Novedad, TrackingSync.Model.Elastic.Novedad>
  {
    public TrackingSync.Model.Elastic.Novedad Convert(
      TrackingSync.Model.Novedad source,
      TrackingSync.Model.Elastic.Novedad destination,
      ResolutionContext context)
    {
      TrackingSync.Model.Elastic.Novedad novedad = new TrackingSync.Model.Elastic.Novedad();
      novedad.Fecha = source.Fecha;
      novedad.Evento = source.Evento;
      novedad.Motivo = source.Motivo;
      novedad.Estado = source.Estado;
      novedad.SucursalId = source.SucursalId;
      novedad.Sucursal = source.Sucursal;
      novedad.Proceso = source.Proceso?.Codigo;
      novedad.Sistema = source.Sistema?.Codigo;
      novedad.Submotivo = source.Submotivo;
      novedad.Comentario = source.Comentario;
      IList<TraduccionEvento> traducciones = source.Traducciones;
      novedad.Traduccion = traducciones != null ? traducciones.FirstOrDefault<TraduccionEvento>()?.Descripcion : (string) null;
      destination = novedad;
      return destination;
    }
  }
}
