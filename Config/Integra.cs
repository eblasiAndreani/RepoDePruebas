// Decompiled with JetBrains decompiler
// Type: TrackingSync.Config.Integra
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

namespace TrackingSync.Config
{
  public class Integra
  {
    public const string Name = "INTEGRA";

    public static class Estados
    {
      public const string Siniestro = "sinister";
      public const string Entregado = "delivered";
      public const string RetiroExitoso = "RetiroExitoso";
      public const string Indefinido = "indefinido";
      public const string Rescue = "rescue";
      public const string Rescued = "rescued";
      public const string Visited = "visited";
      public const string EnDestino = "endestino";
      public const string EnRendicion = "enrendicion";
      public const string Declarated = "declarated";
      public const string RENDIDO = "rendido";
      public const string RENDICION = "rendicion";
      public const string PendienteDevolucion = "PendienteDevolucion";
      public const string PendienteRescate = "PendienteRescate";
      public const string Admision = "entered";
      public const string SinisterWithdrawn = "sinisterwithdrawn";
    }

    public static class Eventos
    {
      public const string Rescate = "Rescate";
      public const string PedidoDeDestruccion = "PedidoDeDestruccion";
      public const string IntroduccionDeMotivo = "IntroduccionDeMotivo";
      public const string SolicitudDeRescate = "SolicitudDeRescate";
      public const string RectificacionDeMotivo = "RectificacionDeMotivo";
      public const string Visita = "Visita";
      public const string EnvioPendienteDeDigitalizacion = "EnvioPendienteDeDigitalizacion";
      public const string EnvioFacturadoSap = "EnvioFacturadoSap";
      public const string EnvioEnInformeDeRendicion = "EnvioEnInformeDeRendicion";
      public const string Distribucion = "Distribucion";
      public const string EnvioConDocumentacionFaltante = "EnvioConDocumentacionFaltante";
      public const string EnvioRendido = "EnvioRendido";
      public const string RemitoDigitalizado = "RemitoDigitalizado";
      public const string ValoresRendidosAlRemitente = "ValoresRendidosAlRemitente";
      public const string Reenvio = "Reenvio";
      public const string FinDeCustodiaEvento = "FinCustodiaEnSucursal";
      public const string DevolucionEnvioPlazoVencido = "DevolucionEnvioPlazoVencido";
      public const string DevolucionEnvioRecibidaPlazaInterior = "DevolucionEnvioRecibidaPlazaInterior";
      public const string EnvioConSolicitudDeRetorno = "EnvioConSolicitudDeRetorno";
      public const string ComienzoCustodiaEnSucursal = "ComienzoCustodiaEnSucursal";
      public const string AsignacionACaja = "AsignacionACaja";
      public const string AltaAutomatica = "AltaAutomatica";
      public const string Siniestro = "Siniestro";
    }

    public static class Motivo
    {
      public const string Entregado = "entregado";
      public const string Siniestrado = "siniestrado";
      public const string NoVisitado = "no fue visitado";
      public const string EntregaPorMostradorSubMotivo = "Entregado en Sucursal Andreani";
      public const string Devolucion = "Devolucion";
    }

    public static class SubMotivo
    {
      public const string EnvioAOrigen = "EnvioAOrigen";
    }
  }
}
