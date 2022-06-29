// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Elastic.Export
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using AutoMapper;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TrackingSync.Helper;
using TrackingSync.Model.Integra;
using TrackingSync.SpecialState;

namespace TrackingSync.Model.Elastic
{
  public class Export
  {
    [Text(Name = "numero_envio")]
    public string NumeroAndreani { get; set; }

    [Text(Name = "numero_pedido")]
    public string NumeroPedido { get; set; }

    [Text(Name = "numero_cliente")]
    public string NumeroCliente { get; set; }

    [Nested]
    [PropertyName("sucursal_alta")]
    public Lugar SucursalAlta { get; set; }

    [Nested]
    [PropertyName("sucursal_distribucion")]
    public Lugar SucursalDistribucion { get; set; }

    [Number(Name = "bultos")]
    public int? Bultos { get; set; }

    [Number(Name = "peso")]
    public Decimal? Peso { get; set; }

    [Number(Name = "peso_aforado")]
    public Decimal? PesoAforado { get; set; }

    [Number(Name = "volumen")]
    public Decimal? Volumen { get; set; }

    [Number(Name = "valor_declarado")]
    public Decimal? ValorDeclarado { get; set; }

    [Date(Name = "fecha_novedad_final")]
    public DateTime? FechaNovedadFinal { get; set; }

    [Text(Name = "motivo_novedad_final")]
    public string MotivoNovedadFinal { get; set; }

    [Nested]
    [PropertyName("referencias_export")]
    public Referencia[] Referencias { get; set; }

    [Nested]
    [PropertyName("componentes_envio")]
    public ComponenteDeEnvio[] ComponentesDeEnvio { get; set; }

    [Text(Name = "remitos_hijos")]
    public string RemitosHijos { get; set; }

    [Text(Name = "tipo_informe")]
    public string TipoInforme { get; set; }

    [Text(Name = "numero_informe")]
    public string NumeroInforme { get; set; }

    [Date(Name = "fecha_entrega_informe")]
    public DateTime? FechaEntregaInforme { get; set; }

    [Nested]
    [PropertyName("sucursal_cliente")]
    public Lugar SucursalCliente { get; set; }

    [Text(Name = "estado_gc")]
    public string EstadoGestionCobranza { get; set; }

    [Number(Name = "importe_a_cobrar")]
    public Decimal? ImporteACobrar { get; set; }

    [Number(Name = "importe_cobrado")]
    public Decimal? ImporteCobrado { get; set; }

    [Text(Name = "medio_pago_gestion")]
    public string MedioPagoGestion { get; set; }

    [Date(Name = "fecha_liquidacion")]
    public DateTime? FechaLiquidacion { get; set; }

    [Text(Name = "medio_pago_liquidacion")]
    public string MedioPagoLiquidacion { get; set; }

    [Text(Name = "numero_cheque")]
    public string NumeroCheque { get; set; }

    [Text(Name = "banco")]
    public string Banco { get; set; }

    [Number(Name = "monto_liquidacion")]
    public Decimal? MontoLiquidacion { get; set; }

    [Number(Name = "retencion_liquidacion")]
    public Decimal? RetencionLiquidacion { get; set; }

    [Date(Name = "fecha_probable_entrega")]
    public DateTime? FechaProbableEntrega { get; set; }

    [Date(Name = "fecha_pactada")]
    public DateTime? FechaPactada { get; set; }

    [Date(Name = "fecha_repactada")]
    public DateTime? FechaRepactada { get; set; }

    [Date(Name = "fecha_ingreso_pedido")]
    public DateTime? FechaIngresoPedido { get; set; }

    [Date(Name = "fecha_admision")]
    public DateTime? FechaAdmision { get; set; }

    [Date(Name = "fecha_alta")]
    public DateTime? FechaAltaEnvio { get; set; }

    [Date(Name = "fecha_inicio_distribucion")]
    public DateTime? FechaInicioDistribucion { get; set; }

    [Date(Name = "fecha_ingreso_sucursal")]
    public DateTime? FechaIngresoSucursal { get; set; }

    [Date(Name = "fecha_visita_1")]
    public DateTime? FechaVisita1 { get; set; }

    [Nested]
    [PropertyName("motivo_visita_1")]
    public Traduccion[] MotivoVisita1 { get; set; }

    [Date(Name = "fecha_visita_2")]
    public DateTime? FechaVisita2 { get; set; }

    [Nested]
    [PropertyName("motivo_visita_2")]
    public Traduccion[] MotivoVisita2 { get; set; }

    [Date(Name = "fecha_visita_3")]
    public DateTime? FechaVisita3 { get; set; }

    [Nested]
    [PropertyName("motivo_visita_3")]
    public Traduccion[] MotivoVisita3 { get; set; }

    [Date(Name = "fecha_ingreso_custodia")]
    public DateTime? FechaIngresoCustodia { get; set; }

    [Text(Name = "nro_informe_rendicion")]
    public string NumeroInformeRendicion { get; set; }

    [Text(Name = "cliente")]
    public string Cliente { get; set; }

    [Date(Name = "fecha_vencimiento_custodia")]
    public DateTime? FechaVencimientoCustodia { get; set; }

    [Text(Name = "tipo_entrega")]
    public string TipoEntrega { get; set; }

    [Text(Name = "condicion_entrega")]
    public string CondicionEntrega { get; set; }

    [Text(Name = "cantidad_visitas")]
    public string CantidadDeVisitas { get; set; }

    [Nested]
    [PropertyName("sucursal_custodia")]
    public Sucursal SucursalCustodia { get; set; }

    public Export(TrackingSync.Model.Tracking source)
    {
      string valor1 = source.DatosAdicionales.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals("SucursalOrigen"))).FirstOrDefault<DatosAdicionales>()?.Valor;
      string valor2 = source.DatosAdicionales.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals(nameof (SucursalCustodia)))).FirstOrDefault<DatosAdicionales>()?.Valor;
      string valor3 = source.DatosAdicionales.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals("SucursalDestino"))).FirstOrDefault<DatosAdicionales>()?.Valor;
      string str = this.ObtenerDatoAdicional(source.DatosAdicionales, nameof (ComponentesDeEnvio));
      this.ObtenerDatoAdicional(source.DatosAdicionales, nameof (RemitosHijos));
      string[] references = new string[10]
      {
        "ETI",
        "ALB",
        "DEV",
        "CAO",
        "CAN",
        "FILTRO1",
        "FILTRO2",
        "FILTRO3",
        "FILTRO4",
        "FILTRO5"
      };
      IEnumerable<IGrouping<string, TrackingSync.Model.Novedad>> source1 = this.ObtenerPrimerasTresNovedadesVisitas((IEnumerable<TrackingSync.Model.Novedad>) source.Novedades);
      Tuple<DateTime?, string> tuple = this.EvaluarNovedadFinal(source);
      this.SucursalCustodia = new Sucursal(valor2);
      this.NumeroAndreani = source.Referencias.Where<TrackingSync.Model.Referencia>((Func<TrackingSync.Model.Referencia, bool>) (r => r.Nombre.Equals("NumeroDeEnvio"))).FirstOrDefault<TrackingSync.Model.Referencia>()?.Valor;
      this.NumeroPedido = source.Referencias.Where<TrackingSync.Model.Referencia>((Func<TrackingSync.Model.Referencia, bool>) (r => r.Nombre.Equals("NumeroDePedido"))).FirstOrDefault<TrackingSync.Model.Referencia>()?.Valor;
      this.SucursalAlta = new Lugar(valor1, true);
      this.SucursalDistribucion = new Lugar(valor3, true);
      int result1;
      this.Bultos = int.TryParse(this.ObtenerDatoAdicional(source.DatosAdicionales, "CantidadDeBultos"), out result1) ? new int?(result1) : new int?();
      Decimal result2;
      this.Peso = Decimal.TryParse(this.ObtenerDatoAdicional(source.DatosAdicionales, nameof (Peso)), out result2) ? new Decimal?(result2) : new Decimal?();
      this.PesoAforado = Decimal.TryParse(this.ObtenerDatoAdicional(source.DatosAdicionales, nameof (PesoAforado)), out result2) ? new Decimal?(result2) : new Decimal?();
      this.Volumen = Decimal.TryParse(this.ObtenerDatoAdicional(source.DatosAdicionales, nameof (Volumen)), out result2) ? new Decimal?(result2) : new Decimal?();
      this.ValorDeclarado = Decimal.TryParse(this.ObtenerDatoAdicional(source.DatosAdicionales, nameof (ValorDeclarado)), out result2) ? new Decimal?(result2) : new Decimal?();
      this.FechaNovedadFinal = tuple.Item1;
      this.MotivoNovedadFinal = tuple.Item2;
      this.ImporteACobrar = Decimal.TryParse(this.ObtenerDatoAdicional(source.DatosAdicionales, "ValorACobrar"), out result2) ? new Decimal?(result2) : new Decimal?();
      DateTime result3;
      this.FechaProbableEntrega = DateTime.TryParse(this.ObtenerDatoAdicional(source.DatosAdicionales, "FechaProbableDeEntrega"), out result3) ? new DateTime?(result3) : new DateTime?();
      this.FechaPactada = DateTime.TryParse(this.ObtenerDatoAdicional(source.DatosAdicionales, "FechaPactadaDeEntregaN"), out result3) ? new DateTime?(result3) : new DateTime?();
      this.FechaRepactada = DateTime.TryParse(this.ObtenerDatoAdicional(source.DatosAdicionales, "FechaRePactadaDeEntrega"), out result3) ? new DateTime?(result3) : new DateTime?();
      this.FechaIngresoPedido = source.Novedades.Where<TrackingSync.Model.Novedad>((Func<TrackingSync.Model.Novedad, bool>) (n => n.Evento.Equals("PedidoCreado"))).FirstOrDefault<TrackingSync.Model.Novedad>()?.Fecha;
      this.FechaAltaEnvio = source.Novedades.Where<TrackingSync.Model.Novedad>((Func<TrackingSync.Model.Novedad, bool>) (x => x.Evento == "OrdenDeEnvioCreada" || x.Evento == "AltaRemota" || x.Evento == "AltaPorDevolucion" || x.Evento == "AltaPorRecanalizacion")).FirstOrDefault<TrackingSync.Model.Novedad>()?.Fecha;
      this.FechaAdmision = source.Novedades.Where<TrackingSync.Model.Novedad>((Func<TrackingSync.Model.Novedad, bool>) (n => n.Evento.Equals("Admision") || n.Evento.Equals("Impresion") || n.Evento.Equals("AltaAutomatica") || n.Evento.Equals("AltaManual"))).FirstOrDefault<TrackingSync.Model.Novedad>()?.Fecha;
      this.FechaInicioDistribucion = source.Novedades.Where<TrackingSync.Model.Novedad>((Func<TrackingSync.Model.Novedad, bool>) (n => n.Evento.Equals("ExpedicionHojaDeRutaDeViaje"))).OrderBy<TrackingSync.Model.Novedad, DateTime>((Func<TrackingSync.Model.Novedad, DateTime>) (n => n.Fecha)).FirstOrDefault<TrackingSync.Model.Novedad>()?.Fecha;
      this.FechaIngresoSucursal = DateTime.TryParse(this.ObtenerDatoAdicional(source.DatosAdicionales, "FechaRecepcionSucursalDestino"), out result3) ? new DateTime?(result3) : new DateTime?();
      this.FechaIngresoCustodia = source.Novedades.Where<TrackingSync.Model.Novedad>((Func<TrackingSync.Model.Novedad, bool>) (n =>
      {
        if (!n.Evento.Equals("ComienzoCustodiaEnSucursal"))
          return false;
        return n.Proceso.Codigo.Equals("Distribution") || n.Proceso.Codigo.Equals("Resend");
      })).OrderByDescending<TrackingSync.Model.Novedad, DateTime>((Func<TrackingSync.Model.Novedad, DateTime>) (n => n.Fecha)).FirstOrDefault<TrackingSync.Model.Novedad>()?.Fecha;
      IGrouping<string, TrackingSync.Model.Novedad> source2 = source1.ElementAtOrDefault<IGrouping<string, TrackingSync.Model.Novedad>>(0);
      this.FechaVisita1 = source2 != null ? source2.LastOrDefault<TrackingSync.Model.Novedad>()?.Fecha : new DateTime?();
      IGrouping<string, TrackingSync.Model.Novedad> source3 = source1.ElementAtOrDefault<IGrouping<string, TrackingSync.Model.Novedad>>(1);
      this.FechaVisita2 = source3 != null ? source3.LastOrDefault<TrackingSync.Model.Novedad>()?.Fecha : new DateTime?();
      IGrouping<string, TrackingSync.Model.Novedad> source4 = source1.ElementAtOrDefault<IGrouping<string, TrackingSync.Model.Novedad>>(2);
      this.FechaVisita3 = source4 != null ? source4.LastOrDefault<TrackingSync.Model.Novedad>()?.Fecha : new DateTime?();
      IGrouping<string, TrackingSync.Model.Novedad> source5 = source1.ElementAtOrDefault<IGrouping<string, TrackingSync.Model.Novedad>>(0);
      this.MotivoVisita1 = Mapper.Map<Traduccion[]>(source5 != null ? (object) source5.LastOrDefault<TrackingSync.Model.Novedad>()?.Traducciones : (object) (IList<TraduccionEvento>) null);
      IGrouping<string, TrackingSync.Model.Novedad> source6 = source1.ElementAtOrDefault<IGrouping<string, TrackingSync.Model.Novedad>>(1);
      this.MotivoVisita2 = Mapper.Map<Traduccion[]>(source6 != null ? (object) source6.LastOrDefault<TrackingSync.Model.Novedad>()?.Traducciones : (object) (IList<TraduccionEvento>) null);
      IGrouping<string, TrackingSync.Model.Novedad> source7 = source1.ElementAtOrDefault<IGrouping<string, TrackingSync.Model.Novedad>>(2);
      this.MotivoVisita3 = Mapper.Map<Traduccion[]>(source7 != null ? (object) source7.LastOrDefault<TrackingSync.Model.Novedad>()?.Traducciones : (object) (IList<TraduccionEvento>) null);
      this.Referencias = Mapper.Map<Referencia[]>((object) source.Referencias.Where<TrackingSync.Model.Referencia>((Func<TrackingSync.Model.Referencia, bool>) (r => ((IEnumerable<string>) references).Contains<string>(r.Codigo.ToUpper()))));
      this.NumeroInformeRendicion = source.Referencias.Where<TrackingSync.Model.Referencia>((Func<TrackingSync.Model.Referencia, bool>) (r => r.Nombre.Equals(nameof (NumeroInformeRendicion)))).FirstOrDefault<TrackingSync.Model.Referencia>()?.Valor;
      this.Cliente = this.ObtenerDatoAdicional(source.DatosAdicionales, nameof (Cliente));
      this.FechaVencimientoCustodia = this.ObtenerFechaVencimientoCustodia(source);
      this.ComponentesDeEnvio = str != null ? JsonConvert.DeserializeObject<ComponenteDeEnvio[]>(str) : (ComponenteDeEnvio[]) null;
      this.RemitosHijos = this.ObtenerDatoAdicional(source.DatosAdicionales, nameof (RemitosHijos));
      this.TipoEntrega = this.ObtenerDatoAdicional(source.DatosAdicionales, "TipoDeEntrega");
      this.CantidadDeVisitas = this.ObtenerDatoAdicional(source.DatosAdicionales, nameof (CantidadDeVisitas));
      this.CondicionEntrega = this.ObtenerDatoAdicional(source.DatosAdicionales, "CondicionDeEntrega");
    }

    private DateTime? ObtenerFechaVencimientoCustodia(TrackingSync.Model.Tracking source)
    {
      int diasAAgregar = this.ObtenerDiasCustodia(source.DatosAdicionales);
      if (diasAAgregar == 0)
      {
        DateTime result;
        return DateTime.TryParse(this.ObtenerDatoAdicional(source.DatosAdicionales, "VencimientoCustodia"), out result) ? new DateTime?(result) : new DateTime?();
      }
      TrackingSync.Model.Novedad novedad1 = source.Novedades.FirstOrDefault<TrackingSync.Model.Novedad>((Func<TrackingSync.Model.Novedad, bool>) (n => n.Evento.Equals("AsignacionACaja")));
      TrackingSync.Model.Novedad novedad2 = source.Novedades.FirstOrDefault<TrackingSync.Model.Novedad>((Func<TrackingSync.Model.Novedad, bool>) (n => n.Evento.Equals("ComienzoCustodiaEnSucursal")));
      int num;
      if (novedad1 != null)
      {
        DateTime? fecha1 = novedad1?.Fecha;
        DateTime? fecha2 = novedad2?.Fecha;
        num = fecha1.HasValue & fecha2.HasValue ? (fecha1.GetValueOrDefault() >= fecha2.GetValueOrDefault() ? 1 : 0) : 0;
      }
      else
        num = 0;
      return num != 0 ? new DateTime?(this.AgregarDiasSiSonLaborables(novedad1.Fecha, diasAAgregar)) : new DateTime?();
    }

    private int ObtenerDiasCustodia(IList<DatosAdicionales> datosAdicionales)
    {
      int result;
      int.TryParse(this.ObtenerDatoAdicional(datosAdicionales, "DiasCustodia"), out result);
      return result;
    }

    private DateTime AgregarDiasSiSonLaborables(DateTime fecha, int diasAAgregar)
    {
      while (diasAAgregar > 0)
      {
        fecha = fecha.AddDays(1.0);
        if (fecha.DayOfWeek != DayOfWeek.Saturday && fecha.DayOfWeek != DayOfWeek.Sunday && !Cache.Instance.Resolver<DateTime>("Feriados").Contains(fecha.Date))
          --diasAAgregar;
      }
      return fecha;
    }

    private IEnumerable<IGrouping<string, TrackingSync.Model.Novedad>> ObtenerPrimerasTresNovedadesVisitas(
      IEnumerable<TrackingSync.Model.Novedad> novedades)
    {
      return Export.AgruparVisitas(this.EliminarVisitasCanceladasPorRectificacionesYRectificaciones(novedades.Where<TrackingSync.Model.Novedad>((Func<TrackingSync.Model.Novedad, bool>) (n =>
      {
        if (n.Evento.Equals("Visita") && n.Motivo?.ToLower() != "no fue visitado")
          return true;
        return n.Evento.Equals("RectificacionDeMotivo") && n.Motivo?.ToLower() != "siniestrado";
      })).OrderByDescending<TrackingSync.Model.Novedad, DateTime>((Func<TrackingSync.Model.Novedad, DateTime>) (n => n.Fecha)).ThenByDescending<TrackingSync.Model.Novedad, string>((Func<TrackingSync.Model.Novedad, string>) (n => n.NumeroOrden)).ToList<TrackingSync.Model.Novedad>()));
    }

    private IEnumerable<TrackingSync.Model.Novedad> EliminarVisitasCanceladasPorRectificacionesYRectificaciones(
      List<TrackingSync.Model.Novedad> novedadesVisitasYRectificaciones)
    {
      List<TrackingSync.Model.Novedad> second = new List<TrackingSync.Model.Novedad>();
      string empty = string.Empty;
      TrackingSync.Model.Novedad novedad = (TrackingSync.Model.Novedad) null;
      foreach (TrackingSync.Model.Novedad visitasYrectificacione in novedadesVisitasYRectificaciones)
      {
        if (visitasYrectificacione.Evento.Equals("RectificacionDeMotivo"))
        {
          second.Add(visitasYrectificacione);
          novedad = visitasYrectificacione;
        }
        else if (novedad != null)
        {
          visitasYrectificacione.Motivo = novedad.Motivo;
          visitasYrectificacione.Traducciones = novedad.Traducciones;
          novedad = (TrackingSync.Model.Novedad) null;
        }
      }
      return novedadesVisitasYRectificaciones.Except<TrackingSync.Model.Novedad>((IEnumerable<TrackingSync.Model.Novedad>) second);
    }

    private static IEnumerable<IGrouping<string, TrackingSync.Model.Novedad>> AgruparVisitas(
      IEnumerable<TrackingSync.Model.Novedad> visitas)
    {
      IEnumerable<IGrouping<string, TrackingSync.Model.Novedad>> source1 = visitas.OrderBy<TrackingSync.Model.Novedad, DateTime>((Func<TrackingSync.Model.Novedad, DateTime>) (n => n.Fecha)).GroupBy<TrackingSync.Model.Novedad, string>((Func<TrackingSync.Model.Novedad, string>) (n => n.Fecha.ToString("yyyy-MM-dd")));
      IOrderedEnumerable<IGrouping<string, TrackingSync.Model.Novedad>> orderedEnumerable;
      if (source1 == null)
      {
        orderedEnumerable = (IOrderedEnumerable<IGrouping<string, TrackingSync.Model.Novedad>>) null;
      }
      else
      {
        IOrderedEnumerable<IGrouping<string, TrackingSync.Model.Novedad>> source2 = source1.OrderByDescending<IGrouping<string, TrackingSync.Model.Novedad>, DateTime>((Func<IGrouping<string, TrackingSync.Model.Novedad>, DateTime>) (n => DateTime.Parse(n.Key)));
        if (source2 == null)
        {
          orderedEnumerable = (IOrderedEnumerable<IGrouping<string, TrackingSync.Model.Novedad>>) null;
        }
        else
        {
          IEnumerable<IGrouping<string, TrackingSync.Model.Novedad>> source3 = source2.Take<IGrouping<string, TrackingSync.Model.Novedad>>(3);
          orderedEnumerable = source3 != null ? source3.OrderBy<IGrouping<string, TrackingSync.Model.Novedad>, DateTime>((Func<IGrouping<string, TrackingSync.Model.Novedad>, DateTime>) (n => DateTime.Parse(n.Key))) : (IOrderedEnumerable<IGrouping<string, TrackingSync.Model.Novedad>>) null;
        }
      }
      return (IEnumerable<IGrouping<string, TrackingSync.Model.Novedad>>) orderedEnumerable;
    }

    private Tuple<DateTime?, string> EvaluarNovedadFinal(TrackingSync.Model.Tracking source)
    {
      TrackingSync.Model.Novedad eventoFinal = source.Novedades.Where<TrackingSync.Model.Novedad>((Func<TrackingSync.Model.Novedad, bool>) (n => n.Evento.Equals("EnvioEntregado") || n.Evento.Equals("EnvioNoEntregado") || n.Evento.Equals("RetiroRealizado") || n.Evento.Equals("RetiroFallido"))).OrderByDescending<TrackingSync.Model.Novedad, DateTime>((Func<TrackingSync.Model.Novedad, DateTime>) (x => x.Fecha)).FirstOrDefault<TrackingSync.Model.Novedad>();
      EstadoEspecial estadoEspecial = DiccionarioStrategy.Instance.RetornarEstadoEspecialStrategy(eventoFinal?.Evento);
      return estadoEspecial != null ? estadoEspecial.EvaluarNovedadFinal(eventoFinal, source.SistemaIdUltimaNovedad, source.Novedades) : Tuple.Create<DateTime?, string>(new DateTime?(), "");
    }

    private string ObtenerDatoAdicional(IList<DatosAdicionales> data, string key) => data.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals(key))).FirstOrDefault<DatosAdicionales>()?.Valor;
  }
}
