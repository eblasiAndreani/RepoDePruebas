// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Mapping.TraduccionPreguntaMap
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using FluentNHibernate.Mapping;
using System;
using System.Linq.Expressions;

namespace TrackingSync.Model.Mapping
{
  public class TraduccionPreguntaMap : ClassMap<TraduccionPregunta>
  {
    public TraduccionPreguntaMap()
    {
      this.Table("traduccion_pregunta");
      this.LazyLoad();
      this.Id((Expression<Func<TraduccionPregunta, object>>) (x => (object) x.Id)).GeneratedBy.Identity().Column("id");
      this.Map((Expression<Func<TraduccionPregunta, object>>) (x => x.Pregunta)).Column("pregunta").Not.Nullable();
      this.Map((Expression<Func<TraduccionPregunta, object>>) (x => x.Traduccion)).Column("traduccion").Not.Nullable();
      this.Map((Expression<Func<TraduccionPregunta, object>>) (x => x.Idioma)).Column("idioma").Not.Nullable();
    }
  }
}
