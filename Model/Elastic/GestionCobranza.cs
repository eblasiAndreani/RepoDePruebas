// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Elastic.GestionCobranza
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Nest;
using System;
using System.Collections.Generic;

namespace TrackingSync.Model.Elastic
{
  public class GestionCobranza
  {
    [Number(Name = "importe_total")]
    public virtual Decimal ImporteTotal { get; set; }

    [Nested]
    [PropertyName("formas_de_pago")]
    public virtual IList<TrackingSync.Model.Elastic.FormasDePago> FormasDePago { get; set; }

    public GestionCobranza()
    {
    }

    public GestionCobranza(TrackingSync.Model.GestionCobranza gestionCobranza)
    {
      this.FormasDePago = (IList<TrackingSync.Model.Elastic.FormasDePago>) new List<TrackingSync.Model.Elastic.FormasDePago>();
      this.ImporteTotal = gestionCobranza.ImporteTotal;
      foreach (TrackingSync.Model.FormasDePago formasDePago in (IEnumerable<TrackingSync.Model.FormasDePago>) gestionCobranza.FormasDePago)
        this.FormasDePago.Add(new TrackingSync.Model.Elastic.FormasDePago(formasDePago));
    }
  }
}
