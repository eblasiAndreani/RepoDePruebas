// Decompiled with JetBrains decompiler
// Type: TrackingSync.SpecialState.EstadoEspecialNoEntregado
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using System;
using System.Collections.Generic;
using System.Linq;
using TrackingSync.Model;

namespace TrackingSync.SpecialState
{
  public class EstadoEspecialNoEntregado : EstadoEspecial
  {
    protected override Tuple<DateTime?, string> RetornarEventoAlertran(
      Novedad eventoFinal,
      IList<Novedad> novedades)
    {
      this.novedad = this.ObtenerUltimaVisita(novedades);
      if (this.novedad == null)
        this.novedad = novedades.Where<Novedad>((Func<Novedad, bool>) (n => n.Motivo == "Devolucion" && n.Submotivo == "EnvioAOrigen")).OrderByDescending<Novedad, DateTime>((Func<Novedad, DateTime>) (x => x.Fecha)).FirstOrDefault<Novedad>();
      return Tuple.Create<DateTime?, string>(new DateTime?(eventoFinal.Fecha), this.novedad?.Submotivo);
    }

    protected override Tuple<DateTime?, string> RetornarEventoIntegra(
      IList<Novedad> novedades)
    {
      Novedad novedad = novedades.FirstOrDefault<Novedad>((Func<Novedad, bool>) (n => n.Evento == "FinCustodiaEnSucursal"));
      if (novedad == null)
      {
        this.novedad = this.ObtenerUltimaVisita(novedades);
      }
      else
      {
        this.novedad = novedad;
        this.novedad.Submotivo = "Sin retiro de custodia";
      }
      return Tuple.Create<DateTime?, string>(this.novedad?.Fecha, this.novedad?.Submotivo);
    }
  }
}
