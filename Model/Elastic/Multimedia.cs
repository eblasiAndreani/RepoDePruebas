// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Elastic.Multimedia
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Nest;

namespace TrackingSync.Model.Elastic
{
  public class Multimedia
  {
    [Text(Name = "url")]
    public virtual string Url { get; set; }

    [Text(Name = "url_publica")]
    public virtual string UrlPublica { get; set; }

    [Text(Name = "descripcion")]
    public virtual string Descripcion { get; set; }

    [Text(Name = "tipo_documento")]
    public virtual string TipoDocumento { get; set; }

    [Text(Name = "tipo_archivo")]
    public virtual string TipoArchivo { get; set; }
  }
}
