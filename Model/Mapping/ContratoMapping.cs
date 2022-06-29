// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Mapping.ContratoMapping
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using FluentNHibernate.Mapping;
using System;
using System.Linq.Expressions;

namespace TrackingSync.Model.Mapping
{
  public class ContratoMapping : ClassMap<Contrato>
  {
    public ContratoMapping()
    {
      this.Table("contrato");
      this.Id((Expression<Func<Contrato, object>>) (c => (object) c.Id)).Column("id").GeneratedBy.Identity();
      this.Map((Expression<Func<Contrato, object>>) (c => c.Codigo)).Column("codigo");
      this.References<Cliente>((Expression<Func<Contrato, Cliente>>) (x => x.Cliente)).Column("cliente_id").Nullable();
    }
  }
}
