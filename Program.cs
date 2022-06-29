// Decompiled with JetBrains decompiler
// Type: TrackingSync.Program
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using AutoMapper;
using Infrastructure.FullInfrastructure.Configuration;
using Infrastructure.Host.Owin;
using Infrastructure.IoC.Abstractions;
using Infrastructure.IoC.Windsor;
using Owin;
using System;
using TrackingSync.Converters;
using TrackingSync.Helper;
using TrackingSync.Metrics;

namespace TrackingSync
{
  public class Program : IServiceConfiguration, IServiceStatus
  {
    public ServiceState CurrentState { get; set; }

    public string ServiceDescription => "Keeping Elasticsearch in Sync";

    public string ServiceDisplayName => "Elastic Tracking Sync";

    public string ServiceName => "TrackingSync";

    private static void Main(string[] args) => HostWrapper.Run((IServiceConfiguration) new Program(), (IReadOnlyIocContainer) new WindsorIocContainer(), (Action<WebAppConfigurator>) (config => config.UseBootstrapperProvider((IBootstrapperProvider) new WindsorIocNancyBootstrapper())));

    public void AfterConfiguration(IAppBuilder app)
    {
    }

    public void AfterShutdown()
    {
    }

    public void AfterStart()
    {
    }

    public void AfterStop()
    {
    }

    public void BeforeConfiguration(IAppBuilder app)
    {
    }

    public void BeforeShutdown()
    {
    }

    public void BeforeStart()
    {
      Mapper.Initialize((Action<IMapperConfigurationExpression>) (cfg =>
      {
        cfg.CreateMap<TrackingSync.Model.Pregunta, TrackingSync.Model.Elastic.Pregunta>().ConvertUsing<PreguntaConverter>();
        cfg.CreateMap<TrackingSync.Model.Respuesta, TrackingSync.Model.Elastic.Respuesta>().ConvertUsing<RespuestaConverter>();
        cfg.CreateMap<TrackingSync.Model.Novedad, TrackingSync.Model.Elastic.Novedad>().ConvertUsing<NovedadConverter>();
        cfg.CreateMap<TrackingSync.Model.Multimedia, TrackingSync.Model.Elastic.Multimedia>();
        cfg.CreateMap<TrackingSync.Model.GestionCobranza, TrackingSync.Model.Elastic.GestionCobranza>();
        cfg.CreateMap<TrackingSync.Model.Tracking, TrackingSync.Model.Elastic.Tracking>().ConvertUsing<TrackingConverter>();
      }));
      MetricRegistry.Metrica = new Metrica();
    }

    public void BeforeStop() => ComponentManager.GuardarLasClavesRedisAntesDeApagar();
  }
}
