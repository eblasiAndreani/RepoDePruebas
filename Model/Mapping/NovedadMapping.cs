// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Mapping.NovedadMapping
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using FluentNHibernate.Mapping;
using System;
using System.Linq.Expressions;

namespace TrackingSync.Model.Mapping
{
  public class NovedadMapping : ClassMap<Novedad>
  {
    public NovedadMapping()
    {
      this.Table("novedad");
      this.Id((Expression<Func<Novedad, object>>) (c => (object) c.Id)).Column("id").GeneratedBy.Identity();
      this.Map((Expression<Func<Novedad, object>>) (c => (object) c.TrackingId)).Column("tracking_id").Nullable();
      this.Map((Expression<Func<Novedad, object>>) (c => (object) c.Fecha)).Column("fecha");
      this.Map((Expression<Func<Novedad, object>>) (c => c.Evento)).Column("evento").Nullable();
      this.Map((Expression<Func<Novedad, object>>) (c => c.Motivo)).Column("motivo").Nullable();
      this.Map((Expression<Func<Novedad, object>>) (c => c.Submotivo)).Column("submotivo").Nullable();
      this.Map((Expression<Func<Novedad, object>>) (c => c.NumeroOrden)).Column("numero_orden").Nullable();
      this.Map((Expression<Func<Novedad, object>>) (c => c.Estado)).Column("estado").Nullable();
      this.Map((Expression<Func<Novedad, object>>) (c => (object) c.FechaRegistro)).Column("fecha_registro").Nullable();
      this.Map((Expression<Func<Novedad, object>>) (c => c.Comentario)).Column("comentario").Nullable();
      this.Map((Expression<Func<Novedad, object>>) (c => c.SucursalId)).Column("sucursal_id").Nullable();
      this.Map((Expression<Func<Novedad, object>>) (c => c.Sucursal)).Column("Sucursal").Nullable();
      this.References<Proceso>((Expression<Func<Novedad, Proceso>>) (c => c.Proceso)).Column("proceso_id");
      this.References<Sistema>((Expression<Func<Novedad, Sistema>>) (c => c.Sistema)).Column("sistema_id");
    }
  }
}
