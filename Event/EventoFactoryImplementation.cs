// Decompiled with JetBrains decompiler
// Type: TrackingSync.Event.EventoFactoryImplementation
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using TrackingSync.Model;

namespace TrackingSync.Event
{
  public class EventoFactoryImplementation : IEventoFactory
  {
    public Evento CrearEvento(Tracking tracking)
    {
      switch (tracking.Estado?.ToLower())
      {
        case "declarated":
          return (Evento) new Declarated(tracking);
        case "delivered":
          return (Evento) new Entregado(tracking);
        case "endestino":
          return (Evento) new EnDestino(tracking);
        case "enrendicion":
          return (Evento) new EnRendicion(tracking);
        case "indefinido":
          return (Evento) new Indefinido(tracking);
        case "rescue":
          return (Evento) new Rescue(tracking);
        case "rescued":
          return (Evento) new Rescued(tracking);
        case "sinister":
          return (Evento) new Siniestro(tracking);
        case "visited":
          return (Evento) new Visited(tracking);
        default:
          return (Evento) new DefaultEvent(tracking);
      }
    }
  }
}
