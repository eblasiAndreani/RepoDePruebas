// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.FormasDePago
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using System;

namespace TrackingSync.Model
{
  public class FormasDePago
  {
    public virtual int Id { get; set; }

    public virtual GestionCobranza GestionCobranza { get; set; }

    public virtual string CodigoPago { get; set; }

    public virtual string DescripcionPago { get; set; }

    public virtual DateTime? FechaCobro { get; set; }

    public virtual Decimal Importe { get; set; }

    public virtual int CodigoBanco { get; set; }

    public virtual string NombreBanco { get; set; }

    public virtual string Documento { get; set; }
  }
}
