// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Elastic.Novedad
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Nest;
using System;

namespace TrackingSync.Model.Elastic
{
  public class Novedad
  {
    [Date(Name = "fecha")]
    public DateTime Fecha { get; set; }

    [Text(Name = "evento")]
    public string Evento { get; set; }

    [Text(Name = "motivo")]
    public string Motivo { get; set; }

    [Text(Name = "submotivo")]
    public string Submotivo { get; set; }

    [Text(Name = "estado")]
    public string Estado { get; set; }

    [Text(Name = "comentario")]
    public string Comentario { get; set; }

    [Text(Name = "sucursalId")]
    public string SucursalId { get; set; }

    [Text(Name = "sucursal")]
    public string Sucursal { get; set; }

    [Text(Name = "proceso")]
    public string Proceso { get; set; }

    [Text(Name = "sistema")]
    public string Sistema { get; set; }

    [Text(Name = "traduccion")]
    public string Traduccion { get; set; }

    [Ignore]
    public string NumeroOrden { get; set; }
  }
}
