// Decompiled with JetBrains decompiler
// Type: TrackingSync.Event.Siniestro
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using System;
using System.Collections.Generic;
using System.Linq;
using TrackingSync.Helper;
using TrackingSync.Model;

namespace TrackingSync.Event
{
  public class Siniestro : Evento
  {
    public Siniestro(Tracking tracking) => this.tracking = tracking;

    public override void ObtenerEstadoTecnico()
    {
      DateTime? fechaSiniestro = this.tracking.Novedades.FirstOrDefault<Novedad>((Func<Novedad, bool>) (n => n.Estado.ToLower() == "sinister"))?.Fecha;
      Novedad novedad = this.tracking.Novedades.Where<Novedad>((Func<Novedad, bool>) (n =>
      {
        DateTime fecha = n.Fecha;
        DateTime? nullable = fechaSiniestro;
        return nullable.HasValue && fecha <= nullable.GetValueOrDefault();
      })).OrderByDescending<Novedad, DateTime>((Func<Novedad, DateTime>) (n => n.Fecha)).Skip<Novedad>(1).FirstOrDefault<Novedad>();
      if (novedad.Evento == "RectificacionDeMotivo")
        this.estadoTecnico = "sinisterVisited";
      else
        this.estadoTecnico = "sinister" + novedad?.Estado.ToLower();
      if (!(this.tracking.EventoUltimaNovedad == "RectificacionDeMotivo"))
        return;
      this.ObtenerEstadoTecnicoRectificacionMotivo();
    }

    public override void ResolverTraduccion()
    {
      if (this.estadoTecnico != "")
        this.traduccionEstados = (IList<TraduccionEstado>) Cache.Instance.Resolver<TraduccionEstado>("TraduccionesEstados").Where<TraduccionEstado>((Func<TraduccionEstado, bool>) (t => t.EstadoTecnico.ToLower() == this.estadoTecnico.ToLower())).ToList<TraduccionEstado>();
      else
        this.traduccionEstados = this.tracking.TraduccionesEstados;
    }
  }
}
