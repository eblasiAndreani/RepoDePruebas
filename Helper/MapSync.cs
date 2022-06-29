// Decompiled with JetBrains decompiler
// Type: TrackingSync.Helper.MapSync
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Common.Logging;
using System;
using System.Collections.Generic;
using TrackingSync.Event;
using TrackingSync.Model;

namespace TrackingSync.Helper
{
  public class MapSync
  {
    private static readonly ILog Log = LogManager.GetLogger<MapSync>();
    private IList<TraduccionEstado> traduccionEstadosFinal;
    private IList<TraduccionEstado> traduccionEstados;

    private IEventoFactory EventoFactory { get; set; }

    public MapSync() => this.EventoFactory = (IEventoFactory) new EventoFactoryImplementation();

    public IList<TraduccionEstado> MapEstados(Tracking tracking)
    {
      try
      {
        EventoConEstadoEspecial conEstadoEspecial = new EventoConEstadoEspecial(tracking);
        conEstadoEspecial.ObtenerEstadoTecnico();
        this.traduccionEstados = this.EventoFactory.CrearEvento(tracking).DevolverTraduccion();
        if (conEstadoEspecial.EsSpecial() && conEstadoEspecial.NoEsSiniestrado())
        {
          this.traduccionEstadosFinal = conEstadoEspecial.DevolverTraduccion();
          this.CasoEspecial(tracking.Id);
        }
        else
          this.traduccionEstadosFinal = this.traduccionEstados;
        return this.traduccionEstadosFinal;
      }
      catch (Exception ex)
      {
        MapSync.Log.Error((object) ("No se pudo mapear el estado del envio id :." + tracking.Id.ToString()), ex);
        return tracking.TraduccionesEstados;
      }
    }

    private void CasoEspecial(int id)
    {
      if (this.traduccionEstadosFinal != null)
      {
        this.traduccionEstadosFinal[0].EstadoDetallado = this.traduccionEstados[0] != null ? this.traduccionEstados[0].EstadoDetallado : this.traduccionEstadosFinal[0].EstadoDetallado;
      }
      else
      {
        MapSync.Log.Error((object) ("No se encontro traduccion final del envio id :." + id.ToString()));
        this.traduccionEstadosFinal = this.traduccionEstados;
      }
    }
  }
}
