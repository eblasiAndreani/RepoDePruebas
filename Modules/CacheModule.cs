// Decompiled with JetBrains decompiler
// Type: TrackingSync.Modules.CacheModule
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Common.Logging;
using Nancy;
using System;
using TrackingSync.Helper;

namespace TrackingSync.Modules
{
  public class CacheModule : NancyModule
  {
    private static readonly ILog Log = LogManager.GetLogger<MetricsModule>();

    public CacheModule()
      : base("cache")
    {
      this.Get["/RecycleAndFill"] = (Func<object, object>) (parameters =>
      {
        try
        {
          ComponentManager.ReciclarYLlenarCache();
          return (object) this.Negotiate.WithStatusCode(HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
          CacheModule.Log.Error((object) "Error al setear la cache", ex);
          return (object) this.Negotiate.WithStatusCode(HttpStatusCode.InternalServerError);
        }
      });
      this.Get["/GetEstadosTraducciones"] = (Func<object, object>) (parameters =>
      {
        try
        {
          return (object) ComponentManager.ObtrnerEstadosEnCache();
        }
        catch (Exception ex)
        {
          CacheModule.Log.Error((object) "Error al setear la cache", ex);
          return (object) this.Negotiate.WithStatusCode(HttpStatusCode.InternalServerError);
        }
      });
    }
  }
}
