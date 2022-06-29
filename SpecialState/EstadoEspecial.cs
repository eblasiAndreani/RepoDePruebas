// Decompiled with JetBrains decompiler
// Type: TrackingSync.SpecialState.EstadoEspecial
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using System;
using System.Collections.Generic;
using System.Linq;
using TrackingSync.Model;

namespace TrackingSync.SpecialState
{
  public abstract class EstadoEspecial
  {
    protected Novedad novedad;

    public Tuple<DateTime?, string> EvaluarNovedadFinal(
      Novedad eventoFinal,
      int sistemaId,
      IList<Novedad> novedades)
    {
      return sistemaId == 1 ? this.RetornarEventoAlertran(eventoFinal, novedades) : this.RetornarEventoIntegra(novedades);
    }

    protected Novedad ObtenerUltimaVisita(IList<Novedad> novedades) => novedades.Where<Novedad>((Func<Novedad, bool>) (n => n.Evento == "Visita")).OrderByDescending<Novedad, DateTime>((Func<Novedad, DateTime>) (n => n.Fecha)).FirstOrDefault<Novedad>();

    protected virtual Tuple<DateTime?, string> RetornarEventoAlertran(
      Novedad eventoFinal,
      IList<Novedad> novedades)
    {
      return Tuple.Create<DateTime?, string>(new DateTime?(eventoFinal.Fecha), eventoFinal.Submotivo);
    }

    protected virtual Tuple<DateTime?, string> RetornarEventoIntegra(
      IList<Novedad> novedades)
    {
      this.novedad = this.ObtenerUltimaVisita(novedades);
      return Tuple.Create<DateTime?, string>(this.novedad?.Fecha, this.ObtenerTextoDeNovedad(this.novedad));
    }

    private string ObtenerTextoDeNovedad(Novedad novedad)
    {
      if (!string.IsNullOrEmpty(novedad?.Motivo))
        return novedad.Motivo;
      return !string.IsNullOrEmpty(novedad?.Submotivo) ? novedad.Submotivo : "No hay novedad informada";
    }
  }
}
