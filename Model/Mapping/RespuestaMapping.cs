// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Mapping.RespuestaMapping
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using FluentNHibernate.Mapping;
using System;
using System.Linq.Expressions;

namespace TrackingSync.Model.Mapping
{
  public class RespuestaMapping : ClassMap<Respuesta>
  {
    public RespuestaMapping()
    {
      this.Table("respuesta");
      this.Id((Expression<Func<Respuesta, object>>) (c => (object) c.Id)).Column("id").GeneratedBy.Identity();
      this.Map((Expression<Func<Respuesta, object>>) (c => (object) c.Fecha)).Column("fecha");
      this.Map((Expression<Func<Respuesta, object>>) (c => (object) c.NovedadId)).Column("novedad_id").Nullable();
      this.Map((Expression<Func<Respuesta, object>>) (c => (object) c.PreguntaId)).Column("pregunta_id");
      this.Map((Expression<Func<Respuesta, object>>) (c => (object) c.TrackingId)).Column("tracking_id");
      this.Map((Expression<Func<Respuesta, object>>) (c => c.RespuestaEnum)).Column("respuesta");
      this.Map((Expression<Func<Respuesta, object>>) (c => c.Comentario)).Column("comentario").Nullable();
    }
  }
}
