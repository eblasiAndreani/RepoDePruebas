// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.TraduccionEstado
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

namespace TrackingSync.Model
{
  public class TraduccionEstado
  {
    public virtual int Id { get; set; }

    public virtual string EstadoTecnico { get; set; }

    public virtual string EstadoDetallado { get; set; }

    public virtual string EstadoResumido { get; set; }

    public virtual TraduccionEstado.TipoEstadoEspecial EstadoEspecial { get; set; }

    public virtual string Idioma { get; set; }

    public enum TipoEstadoEspecial
    {
      SinEstado,
      Entrega,
      EntregaRetiro,
    }
  }
}
