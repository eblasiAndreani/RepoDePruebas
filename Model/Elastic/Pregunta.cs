// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Elastic.Pregunta
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Nest;
using System;

namespace TrackingSync.Model.Elastic
{
  public class Pregunta
  {
    [Number(Name = "id")]
    public int Id { get; set; }

    [Date(Name = "fecha")]
    public DateTime Fecha { get; set; }

    [Text(Name = "uRLRespuestas")]
    public string URlRespuesta { get; set; }

    [Boolean(Name = "abierta")]
    public bool Abierta { get; set; }

    [Boolean(Name = "esParaCliente")]
    public bool EsParaCliente { get; set; }

    [Boolean(Name = "procesandoRespuesta")]
    public bool ProcesandoRespuesta { get; set; }

    [Text(Name = "preguntaTraducida")]
    public string PreguntaTraducida { get; set; }

    [Nested]
    [PropertyName("respuestas")]
    public TrackingSync.Model.Elastic.Respuesta[] Respuesta { get; set; }
  }
}
