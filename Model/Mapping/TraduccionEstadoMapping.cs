// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Mapping.TraduccionEstadoMapping
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using FluentNHibernate.Mapping;
using System;
using System.Linq.Expressions;

namespace TrackingSync.Model.Mapping
{
  public class TraduccionEstadoMapping : ClassMap<TraduccionEstado>
  {
    public TraduccionEstadoMapping()
    {
      this.Table("traduccionestado");
      this.Id((Expression<Func<TraduccionEstado, object>>) (c => (object) c.Id)).Column("id").GeneratedBy.Identity();
      this.Map((Expression<Func<TraduccionEstado, object>>) (c => c.EstadoTecnico)).Column("estado_tecnico");
      this.Map((Expression<Func<TraduccionEstado, object>>) (c => c.EstadoDetallado)).Column("estado_detallado");
      this.Map((Expression<Func<TraduccionEstado, object>>) (c => c.EstadoResumido)).Column("estado_resumido");
      this.Map((Expression<Func<TraduccionEstado, object>>) (c => (object) c.EstadoEspecial)).Column("estado_especial").CustomType<int>();
      this.Map((Expression<Func<TraduccionEstado, object>>) (c => c.Idioma)).Column("idioma");
    }
  }
}
