// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Elastic.Telefono
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Nest;

namespace TrackingSync.Model.Elastic
{
  public class Telefono
  {
    [Text(Name = "numero")]
    public string Numero { get; set; }

    [Text(Name = "tipo")]
    public string Tipo { get; set; }
  }
}
