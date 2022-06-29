// Decompiled with JetBrains decompiler
// Type: TrackingSync.Event.EventoConEstadoEspecial
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
  public class EventoConEstadoEspecial : Evento
  {
    private bool esSiniestrado;
    private Novedad novedadConEstadoEspecial;
    private Novedad novedadRectificacionEspecial;

    public EventoConEstadoEspecial(Tracking tracking) => this.tracking = tracking;

    public override void ObtenerEstadoTecnico()
    {
      IOrderedEnumerable<Novedad> orderedEnumerable = this.ObtenerNovedadesEspeciales();
      this.novedadConEstadoEspecial = orderedEnumerable != null ? orderedEnumerable.FirstOrDefault<Novedad>() : (Novedad) null;
      if (this.ExisteNovedadQueDeshabilitaElEstadoEspecial())
        this.estadoTecnico = "";
      else if (this.ObtenerSiEsRectificacionEntregadaOSiniestrada())
      {
        this.ModificarEstadoSiEsRectificacionEntregadaOSiniestrada();
      }
      else
      {
        this.SetearEsSiniestro();
        if (this.esSiniestrado)
          this.CasoSiniestro(orderedEnumerable);
        this.estadoTecnico = this.novedadConEstadoEspecial != null ? this.novedadConEstadoEspecial.Estado : "";
        if (this.EsRescateEntregado())
          this.estadoTecnico = "deliveredRescate";
      }
    }

    private IOrderedEnumerable<Novedad> ObtenerNovedadesEspeciales()
    {
      IEnumerable<Novedad> source = this.tracking.Novedades.Where<Novedad>((Func<Novedad, bool>) (n => ((IEnumerable<string>) this.estadosBuscados).Contains<string>(Cache.Instance.Resolver<TraduccionEstado>("TraduccionesEstados").FirstOrDefault<TraduccionEstado>((Func<TraduccionEstado, bool>) (t => t.EstadoTecnico.ToLower() == n.Estado?.ToLower()))?.EstadoResumido?.ToLower())));
      return source != null ? source.OrderByDescending<Novedad, DateTime>((Func<Novedad, DateTime>) (n => n.Fecha)) : (IOrderedEnumerable<Novedad>) null;
    }

    private bool ExisteNovedadQueDeshabilitaElEstadoEspecial()
    {
      DateTime? fecha1 = this.tracking.Novedades.FirstOrDefault<Novedad>((Func<Novedad, bool>) (n =>
      {
        if (n.Evento == "Reenvio")
          return true;
        return n.Evento == "RectificacionDeMotivo" && n.Motivo?.ToLower() != "entregado" && n.Motivo?.ToLower() != "siniestrado";
      }))?.Fecha;
      DateTime? fecha2 = this.novedadConEstadoEspecial?.Fecha;
      return fecha1.HasValue & fecha2.HasValue && fecha1.GetValueOrDefault() >= fecha2.GetValueOrDefault();
    }

    private bool ObtenerSiEsRectificacionEntregadaOSiniestrada()
    {
      this.novedadRectificacionEspecial = this.tracking.Novedades.FirstOrDefault<Novedad>((Func<Novedad, bool>) (n =>
      {
        if (!(n.Evento == "RectificacionDeMotivo"))
          return false;
        return n.Motivo?.ToLower() == "entregado" || n.Motivo?.ToLower() == "siniestrado";
      }));
      int num;
      if (this.novedadRectificacionEspecial != null)
      {
        DateTime? fecha1 = this.novedadRectificacionEspecial?.Fecha;
        DateTime? fecha2 = this.novedadConEstadoEspecial?.Fecha;
        num = (fecha1.HasValue & fecha2.HasValue ? (fecha1.GetValueOrDefault() >= fecha2.GetValueOrDefault() ? 1 : 0) : 0) != 0 ? 1 : (this.novedadConEstadoEspecial == null ? 1 : 0);
      }
      else
        num = 0;
      return num != 0;
    }

    private void ModificarEstadoSiEsRectificacionEntregadaOSiniestrada()
    {
      if (this.novedadRectificacionEspecial.Motivo?.ToLower() == "entregado")
      {
        if (this.tracking.TipoEnvio == "Logistica Inversa")
          this.estadoTecnico = "RetiroExitoso";
        else
          this.estadoTecnico = "delivered";
      }
      else
      {
        this.estadoTecnico = "sinister";
        this.SetearEsSiniestro();
      }
    }

    private void SetearEsSiniestro() => this.esSiniestrado = this.novedadConEstadoEspecial?.Estado.ToLower() == "sinister";

    private void CasoSiniestro(IOrderedEnumerable<Novedad> novedadesConEstado)
    {
      if (((IEnumerable<string>) this.motivosSiniestrosIndefinidos).Contains<string>(this.novedadConEstadoEspecial.Motivo))
      {
        this.esSiniestrado = false;
        Novedad novedad;
        if (novedadesConEstado == null)
        {
          novedad = (Novedad) null;
        }
        else
        {
          IEnumerable<Novedad> source = novedadesConEstado.Skip<Novedad>(1);
          novedad = source != null ? source.FirstOrDefault<Novedad>() : (Novedad) null;
        }
        this.novedadConEstadoEspecial = novedad;
      }
      else
        this.tracking.Estado = this.novedadConEstadoEspecial.Estado;
    }

    private bool EsRescateEntregado() => this.novedadConEstadoEspecial?.Estado.ToLower() == "delivered" && this.novedadConEstadoEspecial?.Evento == "Rescate";

    public override IList<TraduccionEstado> DevolverTraduccion()
    {
      if ((this.estadoTecnico == "NoEntregado" || this.estadoTecnico == "notDelivered") && this.tracking.Novedades.FirstOrDefault<Novedad>((Func<Novedad, bool>) (n => n.Evento == "EnvioNoEntregado")) != null)
        this.estadoTecnico = this.tracking.Novedades.FirstOrDefault<Novedad>((Func<Novedad, bool>) (n => n.Evento == "EnvioNoEntregado")).Estado;
      return (IList<TraduccionEstado>) Cache.Instance.Resolver<TraduccionEstado>("TraduccionesEstados").Where<TraduccionEstado>((Func<TraduccionEstado, bool>) (t => t.EstadoTecnico.ToLower() == this.estadoTecnico.ToLower())).ToList<TraduccionEstado>();
    }

    public bool EsSpecial() => this.estadoTecnico != "";

    public bool NoEsSiniestrado() => !this.esSiniestrado;
  }
}
