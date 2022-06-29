// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Elastic.Sucursal
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Nest;
using Newtonsoft.Json.Linq;

namespace TrackingSync.Model.Elastic
{
  public class Sucursal
  {
    public Sucursal(string sucursalCustodia)
    {
      if (sucursalCustodia == null)
        return;
      JObject jobject = JObject.Parse(sucursalCustodia);
      this.SucursalNombre = (string) jobject[nameof (Sucursal)];
      this.Direccion = (string) jobject[nameof (Direccion)];
      this.HorarioAtencion = (string) jobject[nameof (HorarioAtencion)];
    }

    [Text(Name = "sucursal")]
    public string SucursalNombre { get; set; }

    [Text(Name = "direccion")]
    public string Direccion { get; set; }

    [Text(Name = "horario_atencion")]
    public string HorarioAtencion { get; set; }
  }
}
