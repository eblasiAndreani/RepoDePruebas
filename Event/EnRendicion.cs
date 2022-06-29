// Decompiled with JetBrains decompiler
// Type: TrackingSync.Event.EnRendicion
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using TrackingSync.Model;

namespace TrackingSync.Event
{
  public class EnRendicion : Evento
  {
    public EnRendicion(Tracking tracking) => this.tracking = tracking;

    public override void ObtenerEstadoTecnico()
    {
      string eventoUltimaNovedad = this.tracking.EventoUltimaNovedad;
      if (!(eventoUltimaNovedad == "EnvioConDocumentacionFaltante") && !(eventoUltimaNovedad == "Distribucion"))
      {
        if (!(eventoUltimaNovedad == "RemitoDigitalizado") && !(eventoUltimaNovedad == "ValoresRendidosAlRemitente"))
        {
          if (eventoUltimaNovedad == "RectificacionDeMotivo")
            this.ObtenerEstadoTecnicoRectificacionMotivo();
          else
            this.estadoTecnico = "";
        }
        else
          this.estadoTecnico = "rendido";
      }
      else
        this.estadoTecnico = "rendicion";
    }
  }
}
