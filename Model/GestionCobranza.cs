// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.GestionCobranza
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using System;
using System.Collections.Generic;

namespace TrackingSync.Model
{
  public class GestionCobranza
  {
    public virtual int Id { get; set; }

    public virtual int TrackingId { get; set; }

    public virtual Decimal ImporteTotal { get; set; }

    public virtual IList<TrackingSync.Model.FormasDePago> FormasDePago { get; set; }
  }
}
