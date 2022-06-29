// Decompiled with JetBrains decompiler
// Type: TrackingSync.Event.DefaultEvent
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using TrackingSync.Model;

namespace TrackingSync.Event
{
  public class DefaultEvent : Evento
  {
    public DefaultEvent(Tracking tracking) => this.tracking = tracking;

    public override void ObtenerEstadoTecnico()
    {
      if (this.tracking.EventoUltimaNovedad == "RectificacionDeMotivo")
        this.ObtenerEstadoTecnicoRectificacionMotivo();
      else
        this.estadoTecnico = "";
    }
  }
}
