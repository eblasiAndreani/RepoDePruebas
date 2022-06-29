// Decompiled with JetBrains decompiler
// Type: TrackingSync.Metrics.Metrica
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using System;
using System.Collections.Generic;
using System.Linq;

namespace TrackingSync.Metrics
{
  public class Metrica
  {
    public bool SetGauge(string name, double value)
    {
      try
      {
        if (this._gauges.FirstOrDefault<Gauge>((Func<Gauge, bool>) (g => g.name == name)) == null)
          this._gauges.Add(new Gauge()
          {
            name = name,
            value = value,
            unit = "items"
          });
        this._gauges.FirstOrDefault<Gauge>((Func<Gauge, bool>) (g => g.name == name)).value = value;
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public Metrica()
    {
      this._gauges = new List<Gauge>();
      this._gauges.Add(new Gauge()
      {
        name = "Ultimo TrackingID",
        value = 0.0,
        unit = "items"
      });
      List<Gauge> gauges = this._gauges;
      Gauge gauge = new Gauge();
      gauge.name = "Ultimo Timestamp";
      DateTime dateTime = DateTime.MinValue;
      dateTime = dateTime.ToUniversalTime();
      gauge.value = dateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
      gauge.unit = "items";
      gauges.Add(gauge);
    }

    public List<Gauge> Gauges => this._gauges;

    private List<Gauge> _gauges { get; set; }
  }
}
