// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Mapping.MultimediaMapping
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using FluentNHibernate.Mapping;
using System;
using System.Linq.Expressions;

namespace TrackingSync.Model.Mapping
{
  public class MultimediaMapping : ClassMap<Multimedia>
  {
    public MultimediaMapping()
    {
      this.Table("multimedia");
      this.Id((Expression<Func<Multimedia, object>>) (c => (object) c.Id)).Column("id").GeneratedBy.Identity();
      this.Map((Expression<Func<Multimedia, object>>) (c => (object) c.TrackingId)).Column("tracking_id");
      this.Map((Expression<Func<Multimedia, object>>) (c => c.Url)).Column("url");
      this.Map((Expression<Func<Multimedia, object>>) (c => c.TipoArchivo)).Column("tipo_archivo");
      this.Map((Expression<Func<Multimedia, object>>) (c => c.TipoDocumento)).Column("tipo_documento");
      this.Map((Expression<Func<Multimedia, object>>) (c => c.Descripcion)).Column("descripcion").Nullable();
      this.Map((Expression<Func<Multimedia, object>>) (c => c.UrlPublica)).Column("url_publica").Nullable();
    }
  }
}
