// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.TraduccionEvento
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

namespace TrackingSync.Model
{
  public class TraduccionEvento
  {
    public virtual int Id { get; set; }

    public virtual string Evento { get; set; }

    public virtual string Motivo { get; set; }

    public virtual string Submotivo { get; set; }

    public virtual string Descripcion { get; set; }

    public virtual string Idioma { get; set; }

    public virtual int SistemaId { get; set; }

    public virtual int? ProcesoId { get; set; }

    public virtual string TipoEnvio { get; set; }
  }
}
