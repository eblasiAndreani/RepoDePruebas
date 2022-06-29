// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Mapping.FormasDePagoMapping
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using FluentNHibernate.Mapping;
using System;
using System.Linq.Expressions;

namespace TrackingSync.Model.Mapping
{
  public class FormasDePagoMapping : ClassMap<FormasDePago>
  {
    public FormasDePagoMapping()
    {
      this.Table("gestion_cobranza_fp");
      this.Id((Expression<Func<FormasDePago, object>>) (c => (object) c.Id)).Column("id").GeneratedBy.Identity();
      this.Map((Expression<Func<FormasDePago, object>>) (c => c.CodigoPago)).Column("codigo_pago");
      this.Map((Expression<Func<FormasDePago, object>>) (c => c.DescripcionPago)).Column("descripcion_pago");
      this.Map((Expression<Func<FormasDePago, object>>) (c => (object) c.FechaCobro)).Column("fecha_cobro").Nullable();
      this.Map((Expression<Func<FormasDePago, object>>) (c => (object) c.Importe)).Column("importe");
      this.Map((Expression<Func<FormasDePago, object>>) (c => (object) c.CodigoBanco)).Column("codigo_banco");
      this.Map((Expression<Func<FormasDePago, object>>) (c => c.NombreBanco)).Column("nombre_banco");
      this.Map((Expression<Func<FormasDePago, object>>) (c => c.Documento)).Column("documento");
      this.References<GestionCobranza>((Expression<Func<FormasDePago, GestionCobranza>>) (c => c.GestionCobranza)).Column("cobranza_id").LazyLoad();
    }
  }
}
