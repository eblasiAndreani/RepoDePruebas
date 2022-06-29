// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Referencia
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

namespace TrackingSync.Model
{
  public class Referencia
  {
    public virtual int Id { get; set; }

    public virtual string Codigo { get; set; }

    public virtual string Valor { get; set; }

    public virtual string Nombre { get; set; }

    public virtual int TrackingId { get; set; }

    public virtual int Orden { get; set; } = 0;
  }
}
