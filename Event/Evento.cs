// Decompiled with JetBrains decompiler
// Type: TrackingSync.Event.Evento
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Common.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TrackingSync.Helper;
using TrackingSync.Model;

namespace TrackingSync.Event
{
  public abstract class Evento
  {
    public IDictionary<string, string> estadosEspeciales = (IDictionary<string, string>) ((IEnumerable<string>) ConfigurationManager.AppSettings[nameof (estadosEspeciales)].Split(',')).ToDictionary<string, string, string>((Func<string, string>) (k => ((IEnumerable<string>) k.Split(':')).First<string>()), (Func<string, string>) (v => ((IEnumerable<string>) v.Split(':')).Last<string>()));
    public string[] estadosBuscados = ConfigurationManager.AppSettings[nameof (estadosBuscados)].Split(',');
    public string[] motivosSiniestrosIndefinidos = ConfigurationManager.AppSettings[nameof (motivosSiniestrosIndefinidos)].Split(',');
    protected string estadoBuscadoEncontrado;
    protected Tracking tracking;
    protected string estadoTecnico;
    public IList<TraduccionEstado> traduccionEstados;
    private static readonly ILog Log = LogManager.GetLogger<Evento>();

    public virtual void ResolverTraduccion()
    {
      if (this.estadoTecnico != "")
        this.traduccionEstados = (IList<TraduccionEstado>) Cache.Instance.Resolver<TraduccionEstado>("TraduccionesEstados").Where<TraduccionEstado>((Func<TraduccionEstado, bool>) (t => t.EstadoTecnico.ToLower() == this.estadoTecnico.ToLower())).ToList<TraduccionEstado>();
      else
        this.traduccionEstados = this.tracking.TraduccionesEstados;
    }

    public abstract void ObtenerEstadoTecnico();

    protected virtual void CambiarTraduccionConEstadoEspecial()
    {
      List<TraduccionEstado> list = this.traduccionEstados.Where<TraduccionEstado>((Func<TraduccionEstado, bool>) (t => t.EstadoEspecial > TraduccionEstado.TipoEstadoEspecial.SinEstado)).ToList<TraduccionEstado>();
      if (list.Count == 0)
        return;
      List<Novedad> novedadesOrdenadas = this.tracking.Novedades.OrderByDescending<Novedad, DateTime>((Func<Novedad, DateTime>) (n => n.Fecha)).ToList<Novedad>();
      foreach (TraduccionEstado traduccionEstado in list)
        traduccionEstado.EstadoResumido = this.estadosEspeciales.SingleOrDefault<KeyValuePair<string, string>>((Func<KeyValuePair<string, string>, bool>) (s => s.Key == novedadesOrdenadas.Where<Novedad>((Func<Novedad, bool>) (n => this.estadosEspeciales.ContainsKey(n.Evento))).FirstOrDefault<Novedad>()?.Evento)).Value ?? this.estadosEspeciales["Default"];
    }

    public virtual IList<TraduccionEstado> DevolverTraduccion()
    {
      this.ObtenerEstadoTecnico();
      this.ResolverTraduccion();
      this.CambiarTraduccionConEstadoEspecial();
      try
      {
        this.WorkaroundProblemaEstadoNoEntregado();
        this.WorkaroundProblemaEstadoEntregado();
      }
      catch (Exception ex)
      {
        Evento.Log.Error((object) string.Format("Error al intentar corregir - traking {0} - orden {1}", (object) this.tracking.Id, (object) this.tracking.Novedades.FirstOrDefault<Novedad>()?.NumeroOrden), ex);
        throw;
      }
      return this.traduccionEstados;
    }

    private void WorkaroundProblemaEstadoNoEntregado()
    {
      if (!this.ExisteNovedadPorEstado("notdelivered") || !this.ExisteEstadoResumido("entregado"))
        return;
      this.traduccionEstados.Where<TraduccionEstado>((Func<TraduccionEstado, bool>) (y => y.EstadoResumido.ToLowerInvariant() == "entregado")).ToList<TraduccionEstado>().ForEach((Action<TraduccionEstado>) (x => x.EstadoResumido = "NO ENTREGADO"));
      this.LogErrorEstado();
    }

    private void WorkaroundProblemaEstadoEntregado()
    {
      if (!this.ExisteNovedadPorEstado("delivered") || !this.ExisteEstadoResumido("no entregado"))
        return;
      this.traduccionEstados.Where<TraduccionEstado>((Func<TraduccionEstado, bool>) (y => y.EstadoResumido.ToLowerInvariant() == "entregado")).ToList<TraduccionEstado>().ForEach((Action<TraduccionEstado>) (x => x.EstadoResumido = "NO ENTREGADO"));
      this.LogErrorEstado();
    }

    private void LogErrorEstado() => Evento.Log.Warn((object) string.Format("Correccion estado incorrecto - traking {0} - orden {1}", (object) this.tracking.Id, (object) this.tracking.Novedades.FirstOrDefault<Novedad>()?.NumeroOrden));

    private bool ExisteNovedadPorEstado(string estado) => this.tracking.Novedades.Any<Novedad>((Func<Novedad, bool>) (x => x.Estado.ToLowerInvariant() == estado && x.Proceso?.Codigo?.ToLowerInvariant() == "distribution"));

    private bool ExisteEstadoResumido(string estadoResumido) => this.traduccionEstados.Any<TraduccionEstado>((Func<TraduccionEstado, bool>) (y => y.EstadoResumido?.ToLowerInvariant() == estadoResumido));

    protected void ObtenerEstadoTecnicoRectificacionMotivo()
    {
      string lower = this.tracking.MotivoUltimaNovedad?.ToLower();
      if (!(lower == "entregado"))
      {
        if (!(lower == "siniestrado"))
        {
          if (lower == "no fue visitado")
            this.estadoTecnico = "RectificacionDeMotivoNoVisitado";
          else
            this.estadoTecnico = "RectificacionDeMotivovisited";
        }
        else
          this.estadoTecnico = "RectificacionDeMotivosiniestrado";
      }
      else
        this.estadoTecnico = "RectificacionDeMotivoentregado";
    }
  }
}
