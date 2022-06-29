// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Tracking
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using System;
using System.Collections.Generic;

namespace TrackingSync.Model
{
  public class Tracking
  {
    public virtual int Id { get; set; }

    public virtual string Estado { get; set; }

    public virtual DateTime? FechaAlta { get; set; }

    public virtual DateTime? FechaPrimeraNovedad { get; set; }

    public virtual DateTime? FechaUltimaNovedad { get; set; }

    public virtual string EventoUltimaNovedad { get; set; }

    public virtual string MotivoUltimaNovedad { get; set; }

    public virtual string SubmotivoUltimaNovedad { get; set; }

    public virtual int SistemaIdUltimaNovedad { get; set; }

    public virtual int ProcesoIdUltimaNovedad { get; set; }

    public virtual Contrato Contrato { get; set; }

    public virtual IList<Referencia> Referencias { get; set; }

    public virtual IList<Novedad> Novedades { get; set; }

    public virtual IList<TrackingSync.Model.DatosAdicionales> DatosAdicionales { get; set; }

    public virtual IList<Multimedia> Multimedias { get; set; }

    public virtual bool Visible { get; set; }

    public virtual IList<TraduccionEvento> Traducciones { get; set; }

    public virtual IList<TraduccionEstado> TraduccionesEstados { get; set; }

    public virtual IList<Pregunta> Preguntas { get; set; }

    public virtual IList<TrackingSync.Model.GestionCobranza> GestionCobranza { get; set; }

    public virtual string TipoEnvio { get; set; }
  }
}
