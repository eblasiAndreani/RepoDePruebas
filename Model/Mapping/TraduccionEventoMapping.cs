// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Mapping.TraduccionEventoMapping
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using FluentNHibernate.Mapping;
using System;
using System.Linq.Expressions;

namespace TrackingSync.Model.Mapping
{
  public class TraduccionEventoMapping : ClassMap<TraduccionEvento>
  {
    public TraduccionEventoMapping()
    {
      this.ReadOnly();
      this.Table("traduccionevento");
      this.Id((Expression<Func<TraduccionEvento, object>>) (c => (object) c.Id)).Column("id").GeneratedBy.Identity();
      this.Map((Expression<Func<TraduccionEvento, object>>) (c => c.Evento)).Column("evento");
      this.Map((Expression<Func<TraduccionEvento, object>>) (c => c.Motivo)).Column("motivo");
      this.Map((Expression<Func<TraduccionEvento, object>>) (c => c.Submotivo)).Column("submotivo");
      this.Map((Expression<Func<TraduccionEvento, object>>) (c => c.Descripcion)).Column("descripcion");
      this.Map((Expression<Func<TraduccionEvento, object>>) (c => c.Idioma)).Column("idioma");
      this.Map((Expression<Func<TraduccionEvento, object>>) (c => (object) c.SistemaId)).Column("sistema_id");
      this.Map((Expression<Func<TraduccionEvento, object>>) (c => (object) c.ProcesoId)).Column("proceso_id");
      this.Map((Expression<Func<TraduccionEvento, object>>) (c => c.TipoEnvio)).Column("tipo_envio");
    }
  }
}
