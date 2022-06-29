// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Pregunta
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using System;
using System.Collections.Generic;

namespace TrackingSync.Model
{
  public class Pregunta
  {
    public virtual string Evento { get; set; }

    public virtual int Id { get; set; }

    public virtual DateTime Fecha { get; set; }

    public virtual string URLRespuestas { get; set; }

    public virtual bool Abierta { get; set; }

    public virtual bool EsParaCliente { get; set; }

    public virtual string PreguntaEnum { get; set; }

    public virtual bool ProcesandoRespuesta { get; set; }

    public virtual int NovedadId { get; set; }

    public virtual int TrackingId { get; set; }

    public virtual IList<Respuesta> Respuestas { get; set; }
  }
}
