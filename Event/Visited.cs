// Decompiled with JetBrains decompiler
// Type: TrackingSync.Event.Visited
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using TrackingSync.Model;

namespace TrackingSync.Event
{
  public class Visited : Evento
  {
    public Visited(Tracking tracking) => this.tracking = tracking;

    public override void ObtenerEstadoTecnico()
    {
      string eventoUltimaNovedad = this.tracking.EventoUltimaNovedad;
      if (!(eventoUltimaNovedad == "RectificacionDeMotivo"))
      {
        if (eventoUltimaNovedad == "Visita")
          this.ObtenerEstadoTecnicoVisita();
        else
          this.estadoTecnico = string.Empty;
      }
      else
        this.ObtenerEstadoTecnicoRectificacionMotivo();
    }

    private void ObtenerEstadoTecnicoVisita()
    {
      if (this.tracking.MotivoUltimaNovedad.ToLower() == "siniestrado")
        this.estadoTecnico = "sinistervisited";
      else
        this.estadoTecnico = string.Empty;
    }
  }
}
