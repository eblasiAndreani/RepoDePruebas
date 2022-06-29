// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Mapping.TrackingMapping
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TrackingSync.Model.Mapping
{
  public class TrackingMapping : ClassMap<Tracking>
  {
    public TrackingMapping()
    {
      this.Table("tracking");
      this.Id((Expression<Func<Tracking, object>>) (c => (object) c.Id)).Column("id").GeneratedBy.Identity();
      this.Map((Expression<Func<Tracking, object>>) (c => c.Estado)).Column("estado").Nullable();
      this.Map((Expression<Func<Tracking, object>>) (c => (object) c.FechaAlta)).Column("fecha_alta").Nullable();
      this.Map((Expression<Func<Tracking, object>>) (c => (object) c.FechaPrimeraNovedad)).Column("fecha_primera_novedad");
      this.Map((Expression<Func<Tracking, object>>) (c => (object) c.FechaUltimaNovedad)).Column("fecha_ultima_novedad").Nullable();
      this.Map((Expression<Func<Tracking, object>>) (c => c.EventoUltimaNovedad)).Column("evento_ultima_novedad");
      this.Map((Expression<Func<Tracking, object>>) (c => c.MotivoUltimaNovedad)).Column("motivo_ultima_novedad");
      this.Map((Expression<Func<Tracking, object>>) (c => c.SubmotivoUltimaNovedad)).Column("submotivo_ultima_novedad");
      this.Map((Expression<Func<Tracking, object>>) (c => (object) c.SistemaIdUltimaNovedad)).Column("sistema_id_ultima_novedad");
      this.Map((Expression<Func<Tracking, object>>) (c => (object) c.ProcesoIdUltimaNovedad)).Column("proceso_id_ultima_novedad");
      this.References<Contrato>((Expression<Func<Tracking, Contrato>>) (c => c.Contrato)).Column("contrato_id").ReadOnly();
      this.HasMany<Referencia>((Expression<Func<Tracking, IEnumerable<Referencia>>>) (c => c.Referencias)).Table("referencia").KeyColumn("tracking_id");
      this.HasMany<Novedad>((Expression<Func<Tracking, IEnumerable<Novedad>>>) (c => c.Novedades)).Table("novedad").OrderBy("fecha desc").KeyColumn("tracking_id");
      this.HasMany<DatosAdicionales>((Expression<Func<Tracking, IEnumerable<DatosAdicionales>>>) (c => c.DatosAdicionales)).Table("datosadicionales").KeyColumn("tracking_id");
      this.HasMany<Multimedia>((Expression<Func<Tracking, IEnumerable<Multimedia>>>) (c => c.Multimedias)).Table("multimedia").KeyColumn("tracking_id");
      this.Map((Expression<Func<Tracking, object>>) (c => (object) c.Visible)).Column("visible");
      this.HasMany<TraduccionEstado>((Expression<Func<Tracking, IEnumerable<TraduccionEstado>>>) (c => c.TraduccionesEstados)).Table("traduccionestado").KeyColumn("estado_tecnico").PropertyRef("Estado");
      this.HasMany<Pregunta>((Expression<Func<Tracking, IEnumerable<Pregunta>>>) (c => c.Preguntas)).Table("pregunta").KeyColumn("tracking_id");
      this.HasMany<GestionCobranza>((Expression<Func<Tracking, IEnumerable<GestionCobranza>>>) (c => c.GestionCobranza)).Table("gestion_cobranza").KeyColumn("tracking_id");
    }
  }
}
