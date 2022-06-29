// Decompiled with JetBrains decompiler
// Type: TrackingSync.Helper.ComponentManager
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using Infrastructure.FullInfrastructure.DataAccess;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using TrackingSync.Model;

namespace TrackingSync.Helper
{
  public static class ComponentManager
  {
    private static ISessionFactory sessionFactory;

    public static ISessionFactory SessionFactory
    {
      get => ComponentManager.sessionFactory;
      set => ComponentManager.sessionFactory = value;
    }

    public static void TiempoDeRefresco()
    {
      if (!Cache.Instance.CalcularSiDebeRefrescar())
        return;
      ComponentManager.ReciclarYLlenarCache();
    }

    public static void ReciclarYLlenarCache()
    {
      Cache.Reciclar();
      using (ISession session = ComponentManager.SessionFactory.OpenAndBindSession())
      {
        Cache.Instance.Insertar<IList<TraduccionEstado>>("TraduccionesEstados", session.QueryOver<TraduccionEstado>().List());
        Cache.Instance.Insertar<IList<TraduccionEvento>>("TraduccionesEventos", session.QueryOver<TraduccionEvento>().List());
        Cache.Instance.Insertar<IList<TraduccionPregunta>>("TraduccionesPregunta", session.QueryOver<TraduccionPregunta>().List());
        Cache.Instance.Insertar<IList<TraduccionRespuesta>>("TraduccionesRespuesta", session.QueryOver<TraduccionRespuesta>().List());
        Cache.Instance.Insertar<List<DateTime>>("Feriados", DalFeriados.ObtenerFeriados());
      }
    }

    public static List<TraduccionEstado> ObtrnerEstadosEnCache() => Cache.Instance.Resolver<TraduccionEstado>("TraduccionesEstados").ToList<TraduccionEstado>();

    public static void GuardarLasClavesRedisAntesDeApagar()
    {
      string val = RedisItems.Instance.ObtenerListaDeValoreRedis();
      using (ComponentManager.SessionFactory.OpenAndBindSession())
        ComponentManager.sessionFactory.GetCurrentSession().CreateSQLQuery(" exec InsertResincronizarRedis ?,? ").SetParameter<string>(0, val).SetParameter<string>(1, RedisItems.Instance.QueueName).ExecuteUpdate();
    }
  }
}
