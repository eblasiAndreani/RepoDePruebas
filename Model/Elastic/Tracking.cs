// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Elastic.Tracking
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Nest;
using System;

namespace TrackingSync.Model.Elastic
{
  public class Tracking
  {
    public long id { get; set; }

    [PropertyName("numero_andreani")]
    public string NumeroAndreani { get; set; }

    [Text(Name = "referencia_principal")]
    public string ReferenciaPrincipal { get; set; }

    [Text(Name = "referencia_cliente")]
    public string ReferenciaCliente { get; set; }

    [Date(Name = "fecha_alta")]
    public DateTime FechaAlta { get; set; }

    [Text(Name = "estado")]
    public string Estado { get; set; }

    [Text(Name = "servicio")]
    public string Servicio { get; set; }

    [Date(Name = "fecha_primera_novedad")]
    public DateTime FechaPrimeraNovedad { get; set; }

    [Date(Name = "fecha_ultima_novedad")]
    public DateTime FechaUltimaNovedad { get; set; }

    [Nested]
    [PropertyName("multimedias")]
    public Multimedia[] Multimedias { get; set; }

    [Object(Name = "referencias")]
    public string[] Referencias { get; set; }

    [Nested]
    [PropertyName("origen")]
    public Lugar Origen { get; set; }

    [Nested]
    [PropertyName("destino")]
    public Lugar Destino { get; set; }

    [Nested]
    [PropertyName("destino_anterior")]
    public Lugar DestinoAnterior { get; set; }

    [Nested]
    [PropertyName("remitente")]
    public DatosPersonales Remitente { get; set; }

    [Nested]
    [PropertyName("destinatario")]
    public DatosPersonales Destinatario { get; set; }

    [Text(Name = "contrato.codigo")]
    public string CodigoContrato { get; set; }

    [Text(Name = "cliente.codigo")]
    public string CodigoCliente { get; set; }

    [Nested]
    [PropertyName("novedades")]
    public Novedad[] Novedades { get; set; }

    [Nested]
    [PropertyName("traducciones")]
    public Traduccion[] Traducciones { get; set; }

    [Boolean(Name = "preguntas_abiertas")]
    public bool PreguntasAbiertas { get; set; }

    [Nested]
    [PropertyName("estados")]
    public TrackingSync.Model.Elastic.Estado[] Estados { get; set; }

    [Date(Name = "fecha_retiro")]
    public DateTime? FechaRetiro { get; set; }

    [PropertyName("usuarios_asociados")]
    public string[] UsuariosAsociados { get; set; }

    [Text(Name = "pod_ir")]
    public string DatosPODIR { get; set; }

    [Text(Name = "pod")]
    public string DatosPOD { get; set; }

    [Text(Name = "geo")]
    public string DatosGEO { get; set; }

    [Text(Name = "tipo_pedido")]
    public string Pedido { get; set; }

    [Nested]
    [PropertyName("gestion_cobranza")]
    public TrackingSync.Model.Elastic.GestionCobranza[] GestionCobranza { get; set; }

    [Nested]
    [PropertyName("export")]
    public Export Export { get; set; }

    [Nested]
    [PropertyName("preguntas")]
    public TrackingSync.Model.Elastic.Pregunta[] Pregunta { get; set; }

    [Text(Name = "recanalizado_por_numero_envio")]
    public string RecanalizadoPorNumeroEnvio { get; set; }

    [Text(Name = "devuelto_por_numero_envio")]
    public string DevueltoPorNumeroEnvio { get; set; }

    [Text(Name = "alta_por_recanalizacion_numero_envio")]
    public string AltaPorRecanalizacionNumeroEnvio { get; set; }

    [Text(Name = "alta_por_devolucion_numero_envio")]
    public string AltaPorDevolucionNumeroEnvio { get; set; }
  }
}
