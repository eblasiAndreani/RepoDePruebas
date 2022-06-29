// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Mapping.PreguntaMapping
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TrackingSync.Model.Mapping
{
  public class PreguntaMapping : ClassMap<Pregunta>
  {
    public PreguntaMapping()
    {
      this.Table("pregunta");
      this.Id((Expression<Func<Pregunta, object>>) (c => (object) c.Id)).Column("id").GeneratedBy.Identity();
      this.Map((Expression<Func<Pregunta, object>>) (c => (object) c.Fecha)).Column("fecha");
      this.Map((Expression<Func<Pregunta, object>>) (c => (object) c.NovedadId)).Column("novedad_id").Nullable();
      this.Map((Expression<Func<Pregunta, object>>) (c => c.URLRespuestas)).Column("url_posibles_respuestas");
      this.Map((Expression<Func<Pregunta, object>>) (c => (object) c.TrackingId)).Column("tracking_id");
      this.Map((Expression<Func<Pregunta, object>>) (c => c.PreguntaEnum)).Column("pregunta");
      this.Map((Expression<Func<Pregunta, object>>) (c => (object) c.Abierta)).Column("abierta");
      this.Map((Expression<Func<Pregunta, object>>) (c => (object) c.EsParaCliente)).Column("es_para_cliente");
      this.Map((Expression<Func<Pregunta, object>>) (c => (object) c.ProcesandoRespuesta)).Column("procesando_rta");
      this.HasMany<Respuesta>((Expression<Func<Pregunta, IEnumerable<Respuesta>>>) (c => c.Respuestas)).Table("respuesta").KeyColumn("pregunta_id");
    }
  }
}
