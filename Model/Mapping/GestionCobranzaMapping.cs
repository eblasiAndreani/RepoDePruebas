// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Mapping.GestionCobranzaMapping
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TrackingSync.Model.Mapping
{
  public class GestionCobranzaMapping : ClassMap<GestionCobranza>
  {
    public GestionCobranzaMapping()
    {
      this.Table("gestion_cobranza");
      this.Id((Expression<Func<GestionCobranza, object>>) (c => (object) c.Id)).Column("id").GeneratedBy.Identity();
      this.Map((Expression<Func<GestionCobranza, object>>) (c => (object) c.TrackingId)).Column("tracking_id");
      this.Map((Expression<Func<GestionCobranza, object>>) (c => (object) c.ImporteTotal)).Column("importe_total");
      this.HasMany<FormasDePago>((Expression<Func<GestionCobranza, IEnumerable<FormasDePago>>>) (c => c.FormasDePago)).Cascade.All().KeyColumn("cobranza_id").LazyLoad();
    }
  }
}
