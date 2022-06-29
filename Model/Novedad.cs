// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Novedad
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using System;
using System.Collections.Generic;

namespace TrackingSync.Model
{
  public class Novedad
  {
    public virtual int Id { get; set; }

    public virtual int? TrackingId { get; set; }

    public virtual DateTime Fecha { get; set; }

    public virtual string Evento { get; set; }

    public virtual string Motivo { get; set; }

    public virtual string Submotivo { get; set; }

    public virtual string NumeroOrden { get; set; }

    public virtual string Estado { get; set; }

    public virtual DateTime? FechaRegistro { get; set; }

    public virtual string Comentario { get; set; }

    public virtual string SucursalId { get; set; }

    public virtual string Sucursal { get; set; }

    public virtual Proceso Proceso { get; set; }

    public virtual Sistema Sistema { get; set; }

    public virtual IList<TraduccionEvento> Traducciones { get; set; }
  }
}
