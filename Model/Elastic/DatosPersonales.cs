// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Elastic.DatosPersonales
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Nest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TrackingSync.Model.Elastic
{
  public class DatosPersonales
  {
    [Text(Name = "nombre")]
    public string Nombre { get; set; }

    [Text(Name = "numero_documento")]
    public string NumeroDocumento { get; set; }

    [Text(Name = "email")]
    public string Email { get; set; }

    [Nested]
    [PropertyName("telefono")]
    public List<TrackingSync.Model.Elastic.Telefono> Telefono { get; set; }

    public DatosPersonales()
    {
    }

    public DatosPersonales(string source)
    {
      try
      {
        this.Telefono = new List<TrackingSync.Model.Elastic.Telefono>();
        JObject jobject = JObject.Parse(source);
        List<JToken> jtokenList = jobject["telefonos"] != null ? jobject["telefonos"].ToList<JToken>() : new List<JToken>();
        this.Nombre = (string) jobject["nombreCompleto"];
        this.NumeroDocumento = (string) jobject["numeroDeDocumento"];
        this.Email = jobject.TryGetValue("eMail", out JToken _) ? (string) jobject["eMail"] : "";
        foreach (JToken jtoken in jtokenList)
          this.Telefono.Add(new TrackingSync.Model.Elastic.Telefono()
          {
            Numero = (string) jtoken[(object) "numero"],
            Tipo = (string) jtoken[(object) "tipo"]
          });
      }
      catch (ArgumentNullException ex)
      {
        this.EmptyObject();
      }
      catch (JsonReaderException ex)
      {
        this.EmptyObject();
      }
      catch (Exception ex)
      {
        this.EmptyObject();
      }
    }

    public void EmptyObject()
    {
      this.Nombre = "";
      this.Email = "";
      this.NumeroDocumento = "";
      this.Telefono = new List<TrackingSync.Model.Elastic.Telefono>();
    }
  }
}
