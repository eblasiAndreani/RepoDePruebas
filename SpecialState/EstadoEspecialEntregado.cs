// Decompiled with JetBrains decompiler
// Type: TrackingSync.SpecialState.EstadoEspecialEntregado
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using TrackingSync.Model;

namespace TrackingSync.SpecialState
{
  public class EstadoEspecialEntregado : EstadoEspecial
  {
    protected override Tuple<DateTime?, string> RetornarEventoIntegra(
      IList<Novedad> novedades)
    {
      Novedad novedad = novedades.FirstOrDefault<Novedad>((Func<Novedad, bool>) (n => n.Submotivo == "Entregado en Sucursal Andreani"));
      if (novedad == null)
      {
        this.novedad = this.ObtenerUltimaVisita(novedades);
      }
      else
      {
        this.novedad = novedad;
        this.novedad.Motivo = this.ObtenerUltimaVisita(novedades)?.Submotivo;
      }
      return Tuple.Create<DateTime?, string>(this.novedad?.Fecha, this.novedad?.Submotivo);
    }

    protected override Tuple<DateTime?, string> RetornarEventoAlertran(
      Novedad eventoFinal,
      IList<Novedad> novedades)
    {
      string str = "Entregado";
      if (!eventoFinal.Motivo.IsNullOrEmpty())
        str = eventoFinal.Motivo;
      if (!eventoFinal.Submotivo.IsNullOrEmpty())
        str = eventoFinal.Submotivo;
      return Tuple.Create<DateTime?, string>(new DateTime?(eventoFinal.Fecha), str);
    }
  }
}
