// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Respuesta
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using System;

namespace TrackingSync.Model
{
  public class Respuesta
  {
    public virtual int Id { get; set; }

    public virtual string RespuestaEnum { get; set; }

    public virtual DateTime Fecha { get; set; }

    public virtual string Comentario { get; set; }

    public virtual int NovedadId { get; set; }

    public virtual int PreguntaId { get; set; }

    public virtual int TrackingId { get; set; }
  }
}
