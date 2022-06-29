// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Elastic.Estado
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Nest;

namespace TrackingSync.Model.Elastic
{
  public class Estado
  {
    [Text(Name = "estado_detallado")]
    public virtual string EstadoDetallado { get; set; }

    [Text(Name = "estado_resumido")]
    public virtual string EstadoResumido { get; set; }

    [Text(Name = "idioma")]
    public virtual string Idioma { get; set; }
  }
}
