// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Integra.ComponenteDeEnvio
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Nest;
using System.Collections.Generic;

namespace TrackingSync.Model.Integra
{
  public class ComponenteDeEnvio
  {
    [Nested]
    [PropertyName("filtros")]
    public List<string> Filtros { get; set; }

    [Text(Name = "idCliente")]
    public string IdCliente { get; set; }

    [Text(Name = "titular")]
    public string Titular { get; set; }
  }
}
