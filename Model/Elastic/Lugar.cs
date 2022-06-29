// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Elastic.Lugar
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
  public class Lugar
  {
    [Text(Name = "codigo_postal")]
    public string CodigoPostal { get; set; }

    [Text(Name = "descripcion")]
    public string Descripcion { get; set; }

    [Text(Name = "localidad")]
    public string Localidad { get; set; }

    [Nested]
    [PropertyName("domicilio")]
    public Domicilio Domicilio { get; set; }

    [Ignore]
    public string Codigo { get; set; }

    public Lugar()
    {
    }

    public Lugar(string source, bool esSucursal)
    {
      try
      {
        if (esSucursal)
        {
          if (source == null)
            return;
          JObject jobject = JObject.Parse(source);
          this.CodigoPostal = (string) jobject["codigoPostal"];
          this.Codigo = (string) jobject["datosSucursal"][(object) "codigo"];
          this.Descripcion = (string) jobject["datosSucursal"][(object) "nombre"];
          this.Localidad = (string) jobject["localidad"];
          this.Domicilio = new Domicilio()
          {
            Calle = (string) jobject["domicilio"][(object) "calle"],
            Numero = (string) jobject["domicilio"][(object) "numero"],
            Provincia = (string) jobject["domicilio"][(object) "nombreProvincia"]
          };
        }
        else
        {
          JObject jobject = JObject.Parse(source);
          List<JToken> jtokenList = jobject["domicilio"][(object) "componentesDeDireccion"] != null ? jobject["domicilio"][(object) "componentesDeDireccion"].ToList<JToken>() : new List<JToken>();
          this.CodigoPostal = (string) jobject["codigoPostal"];
          this.Descripcion = (string) jobject["descripcion"];
          this.Localidad = (string) jobject["localidad"];
          this.Domicilio = new Domicilio()
          {
            Calle = (string) jobject["domicilio"][(object) "calle"],
            Numero = (string) jobject["domicilio"][(object) "numero"],
            Provincia = (string) jobject["domicilio"][(object) "nombreProvincia"]
          };
          foreach (JToken jtoken in jtokenList)
          {
            string lower = ((string) jtoken[(object) "meta"]).ToLower();
            if (!(lower == "piso"))
            {
              if (lower == "dpto" || lower == "departamento")
                this.Domicilio.Departamento = (string) jtoken[(object) "contenido"];
            }
            else
              this.Domicilio.Piso = (string) jtoken[(object) "contenido"];
          }
        }
      }
      catch (ArgumentNullException ex)
      {
        this.EmptyObject();
      }
      catch (JsonReaderException ex)
      {
        this.EmptyObject();
      }
    }

    public void EmptyObject()
    {
      this.CodigoPostal = "";
      this.Descripcion = "";
      this.Localidad = "";
      this.Domicilio = new Domicilio();
    }
  }
}
