// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Elastic.Respuesta
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Nest;
using System;

namespace TrackingSync.Model.Elastic
{
  public class Respuesta
  {
    [Date(Name = "fecha")]
    public DateTime Fecha { get; set; }

    [Text(Name = "comentario")]
    public string Comentario { get; set; }

    [Text(Name = "respuestaTraducida")]
    public string RespuestaTraducida { get; set; }
  }
}
