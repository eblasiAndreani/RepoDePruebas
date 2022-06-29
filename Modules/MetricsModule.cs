// Decompiled with JetBrains decompiler
// Type: TrackingSync.Modules.MetricsModule
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Common.Logging;
using Nancy;
using System;
using TrackingSync.Metrics;

namespace TrackingSync.Modules
{
  public class MetricsModule : NancyModule
  {
    private static readonly ILog Log = LogManager.GetLogger<MetricsModule>();

    public MetricsModule()
      : base("metrics")
    {
      this.Get["/"] = (Func<object, object>) (parameters =>
      {
        try
        {
          return (object) this.Negotiate.WithStatusCode(HttpStatusCode.OK).WithModel((object) MetricRegistry.Metrica);
        }
        catch (Exception ex)
        {
          MetricsModule.Log.Error((object) "Error al devolver las metricas", ex);
          return (object) this.Negotiate.WithStatusCode(HttpStatusCode.InternalServerError);
        }
      });
    }
  }
}
