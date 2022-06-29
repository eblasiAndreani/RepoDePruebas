// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Elastic.Domicilio
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Nest;

namespace TrackingSync.Model.Elastic
{
  public class Domicilio
  {
    [Text(Name = "calle")]
    public string Calle { get; set; }

    [Text(Name = "numero")]
    public string Numero { get; set; }

    [Text(Name = "provincia")]
    public string Provincia { get; set; }

    [Text(Name = "piso")]
    public string Piso { get; set; }

    [Text(Name = "departamento")]
    public string Departamento { get; set; }

    public Domicilio()
    {
      this.Calle = "";
      this.Numero = "";
      this.Provincia = "";
      this.Piso = "";
      this.Departamento = "";
    }
  }
}
