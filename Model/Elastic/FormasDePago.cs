// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Elastic.FormasDePago
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Nest;
using System;

namespace TrackingSync.Model.Elastic
{
  public class FormasDePago
  {
    [Text(Name = "descripcion_pago")]
    public virtual string DescripcionPago { get; set; }

    [Date(Name = "fecha_cobro")]
    public virtual DateTime? FechaCobro { get; set; }

    [Number(Name = "importe")]
    public virtual Decimal Importe { get; set; }

    [Text(Name = "nombre_banco")]
    public virtual string NombreBanco { get; set; }

    [Text(Name = "documento")]
    public virtual string Documento { get; set; }

    public FormasDePago(TrackingSync.Model.FormasDePago formasDePago)
    {
      this.DescripcionPago = formasDePago.DescripcionPago;
      this.Documento = formasDePago.Documento;
      this.FechaCobro = formasDePago.FechaCobro;
      this.Importe = formasDePago.Importe;
      this.NombreBanco = formasDePago.NombreBanco;
    }
  }
}
