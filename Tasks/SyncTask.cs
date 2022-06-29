// Decompiled with JetBrains decompiler
// Type: TrackingSync.Tasks.SyncTask
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using AutoMapper;
using Castle.Core.Internal;
using Common.Logging;
using Elasticsearch.Net;
using Infrastructure.FullInfrastructure.DataAccess;
using Infrastructure.FullInfrastructure.Misc;
using Infrastructure.FullInfrastructure.Tasks;
using Nest;
using NHibernate;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrackingSync.Helper;
using TrackingSync.Metrics;
using TrackingSync.Model;
using TrackingSync.Model.Bulk;

namespace TrackingSync.Tasks
{
  public class SyncTask : ITaskObject
  {
    private static readonly ILog Log = LogManager.GetLogger<SyncTask>();
    private static TimeSpan autoDispatchWaitIntervall = new TimeSpan(0, 0, 10);
    private AutoResetEvent waitHandler = new AutoResetEvent(false);
    private ISessionFactory sessionFactory;
    private IConnectionMultiplexer redis = (IConnectionMultiplexer) null;
    private IDatabase db = (IDatabase) null;
    private int workingBatchSize;

    public ISessionFactory SessionFactory
    {
      get => this.sessionFactory;
      set => this.sessionFactory = value;
    }

    public int BatchSize { get; set; }

    public string QueueName { get; set; }

    public string IndexName { get; set; }

    public string MappingType { get; set; }

    public int WaitTimeInSeconds { get; set; }

    public int BulkMaxBodySize { get; set; } = 4000000;

    public TimeSpan? WaitTimeout => new TimeSpan?();

    public string TaskName => nameof (SyncTask);

    public IDictionary<string, string> SpecialStates { get; set; }

    public void Start(CancellationToken token)
    {
      ConfigurationOptions configuration = ConfigurationOptions.Parse(ConfigurationManager.AppSettings["RedisConnectionString"]);
      configuration.AbortOnConnectFail = false;
      ConnectionMultiplexer.ConnectAsync(configuration).ContinueWith((Action<Task<ConnectionMultiplexer>>) (t =>
      {
        this.redis = (IConnectionMultiplexer) t.Result;
        this.db = this.redis.GetDatabase();
      })).Wait();
      this.BatchSize = this.BatchSize == 0 ? 1000 : this.BatchSize;
      this.WaitTimeInSeconds = this.WaitTimeInSeconds == 0 ? 300 : this.WaitTimeInSeconds;
      string str1;
      SyncTask.Log.Info((Action<FormatMessageHandler>) (m => str1 = m("The size of the batch to process is [{0}]", new object[1]
      {
        (object) this.workingBatchSize
      })));
      SyncTask.Log.Info((object) "Tracking Elastic Sync Started.");
      Backoff backoff = Backoff.Create(600M, (Decimal) this.WaitTimeInSeconds, 1000);
      ComponentManager.SessionFactory = this.SessionFactory;
      ComponentManager.ReciclarYLlenarCache();
      while (!token.IsCancellationRequested)
      {
        try
        {
          ComponentManager.TiempoDeRefresco();
          this.workingBatchSize = this.BatchSize;
          if (!this.SynchronizeTrackings(token))
          {
            string str2;
            Infrastructure.FullInfrastructure.Misc.Time.Measure((Action) (() => token.WaitHandle.WaitOne(backoff.Next(), false)), (Action<TimeSpan>) (t => SyncTask.Log.Info((Action<FormatMessageHandler>) (m => str2 = m("Elastic Sync was in idle mode for {0} minutes", new object[1]
            {
              (object) (long) t.TotalMinutes
            })))));
          }
          else
          {
            string str3;
            SyncTask.Log.Info((Action<FormatMessageHandler>) (m => str3 = m("Idle mode will not be started, Elastic Sync need keeping up.", Array.Empty<object>())));
            backoff.Reset();
          }
        }
        catch (Exception ex)
        {
          SyncTask.Log.Error((object) "Exception in Elastic Sync.", ex);
          backoff.Reset();
        }
      }
    }

    private bool SynchronizeTrackings(CancellationToken token)
    {
      bool flag = false;
      try
      {
        RedisItems.Instance.QueueEntries = this.db.SortedSetRangeByRank((RedisKey) this.QueueName, stop: ((long) (this.workingBatchSize - 1)));
        if (RedisItems.Instance.QueueEntries.Length != 0)
        {
          this.db.SortedSetRemoveRangeByRank((RedisKey) this.QueueName, 0L, (long) (RedisItems.Instance.QueueEntries.Length - 1));
          string str;
          SyncTask.Log.Info((Action<FormatMessageHandler>) (m => str = m("There are {0} trackings to sync with Elasticsearch. Starting bulk process..", new object[1]
          {
            (object) RedisItems.Instance.QueueEntries.Length
          })));
          BulkOperations bulkData = new BulkOperations();
          Infrastructure.FullInfrastructure.Misc.Time.Measure((Action) (() => bulkData = this.GenerateBulkData(RedisItems.Instance.QueueEntries)), string.Format("GENERATING {0} TRACKINGS", (object) this.workingBatchSize));
          if (!this.BulkData(bulkData))
          {
            SyncTask.Log.Info((object) "Fallo al bulkear en Elastic. Se reencolan los envíos para reprocesarlos");
            ((IEnumerable<RedisValue>) RedisItems.Instance.QueueEntries).ForEach<RedisValue>((Action<RedisValue>) (q => this.db.SortedSetAdd((RedisKey) this.QueueName, (RedisValue) q.ToString(), (double) DateTime.Now.Ticks, When.NotExists)));
          }
          else if (RedisItems.Instance.QueueEntries.Length != this.workingBatchSize)
          {
            SyncTask.Log.Info((object) "Reencolando los envíos que descarté por tamaño");
            ((IEnumerable<RedisValue>) RedisItems.Instance.QueueEntries).Skip<RedisValue>(this.workingBatchSize).ForEach<RedisValue>((Action<RedisValue>) (q => this.db.SortedSetAdd((RedisKey) this.QueueName, (RedisValue) q.ToString(), (double) DateTime.Now.Ticks, When.NotExists)));
          }
        }
      }
      catch (Exception ex)
      {
        SyncTask.Log.Error((object) "Error al procesar el lote de documentos. Reencolando en Redis para volver a procesar.", ex);
        if (RedisItems.Instance.QueueEntries != null && RedisItems.Instance.QueueEntries.Length != 0)
          ((IEnumerable<RedisValue>) RedisItems.Instance.QueueEntries).ForEach<RedisValue>((Action<RedisValue>) (q => this.db.SortedSetAdd((RedisKey) this.QueueName, (RedisValue) q.ToString(), (double) DateTime.Now.Ticks, When.NotExists)));
      }
      finally
      {
        flag = this.db.SortedSetLength((RedisKey) this.QueueName) >= (long) this.workingBatchSize;
      }
      return flag;
    }

    private BulkOperations GenerateBulkData(RedisValue[] entries)
    {
      BulkOperations bulkData = new BulkOperations();
      using (ISession session = this.SessionFactory.OpenAndBindSession())
      {
        session.BeginTransaction(IsolationLevel.ReadUncommitted);
        for (int index = 0; index < entries.Length; ++index)
        {
          RedisValue entry = entries[index];
          List<object> objectList = new List<object>();
          TrackingSync.Model.Tracking tracking = session.Get<TrackingSync.Model.Tracking>((object) int.Parse((string) entry));
          if (tracking != null)
          {
            if (tracking.Visible)
            {
              MetricRegistry.Metrica.SetGauge("Ultimo TrackingID", (double) tracking.Id);
              Metrica metrica = MetricRegistry.Metrica;
              double num;
              if (!tracking.FechaUltimaNovedad.HasValue)
              {
                num = 0.0;
              }
              else
              {
                DateTime universalTime = tracking.FechaUltimaNovedad.Value;
                universalTime = universalTime.ToUniversalTime();
                num = universalTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
              }
              metrica.SetGauge("Ultimo Timestamp", num);
              tracking.TipoEnvio = SyncTask.ObtenerTipoEnvioClasificado(tracking);
              List<TraduccionEvento> list = Cache.Instance.Resolver<TraduccionEvento>("TraduccionesEventos").Where<TraduccionEvento>((Func<TraduccionEvento, bool>) (n =>
              {
                if (n.Evento == tracking.EventoUltimaNovedad && (n.Motivo == tracking.MotivoUltimaNovedad || string.IsNullOrEmpty(n.Motivo)) && (n.Submotivo == tracking.SubmotivoUltimaNovedad || string.IsNullOrEmpty(n.Submotivo)) && n.SistemaId == tracking.SistemaIdUltimaNovedad)
                {
                  int? procesoId = n.ProcesoId;
                  int procesoIdUltimaNovedad = tracking.ProcesoIdUltimaNovedad;
                  if (procesoId.GetValueOrDefault() == procesoIdUltimaNovedad & procesoId.HasValue || !n.ProcesoId.HasValue)
                    return n.TipoEnvio == tracking.TipoEnvio || string.IsNullOrEmpty(n.TipoEnvio);
                }
                return false;
              })).OrderByDescending<TraduccionEvento, string>((Func<TraduccionEvento, string>) (x => x.TipoEnvio)).OrderByDescending<TraduccionEvento, int?>((Func<TraduccionEvento, int?>) (x => x.ProcesoId)).OrderByDescending<TraduccionEvento, string>((Func<TraduccionEvento, string>) (x => x.Motivo)).ToList<TraduccionEvento>();
              tracking.Traducciones = (IList<TraduccionEvento>) list.GroupBy<TraduccionEvento, string>((Func<TraduccionEvento, string>) (x => x.Idioma)).Select<IGrouping<string, TraduccionEvento>, TraduccionEvento>((Func<IGrouping<string, TraduccionEvento>, TraduccionEvento>) (g => g.FirstOrDefault<TraduccionEvento>())).ToList<TraduccionEvento>();
              string str1 = ConfigurationManager.AppSettings["EstadoInicial"];
              string[] source = ConfigurationManager.AppSettings["motivosSiniestrosIndefinidos"].Split(',');
              foreach (TrackingSync.Model.Novedad novedad1 in (IEnumerable<TrackingSync.Model.Novedad>) tracking.Novedades.OrderBy<TrackingSync.Model.Novedad, DateTime>((Func<TrackingSync.Model.Novedad, DateTime>) (x => x.Fecha)))
              {
                TrackingSync.Model.Novedad novedad = novedad1;
                if (novedad.Estado != "Indefinido" || novedad.Estado == "sinister" && ((IEnumerable<string>) source).Contains<string>(novedad.Motivo))
                  str1 = novedad.Estado;
                else
                  novedad.Estado = str1;
                novedad.Traducciones = (IList<TraduccionEvento>) Cache.Instance.Resolver<TraduccionEvento>("TraduccionesEventos").Where<TraduccionEvento>((Func<TraduccionEvento, bool>) (n =>
                {
                  if (n.Evento == novedad.Evento && (n.Motivo == novedad.Motivo || string.IsNullOrEmpty(n.Motivo)) && (n.Submotivo == novedad.Submotivo || string.IsNullOrEmpty(n.Submotivo)))
                  {
                    int sistemaId = n.SistemaId;
                    int? id = novedad.Sistema?.Id;
                    int valueOrDefault = id.GetValueOrDefault();
                    if (sistemaId == valueOrDefault & id.HasValue)
                    {
                      int? procesoId = n.ProcesoId;
                      int? nullable = novedad.Proceso?.Id;
                      if (!(procesoId.GetValueOrDefault() == nullable.GetValueOrDefault() & procesoId.HasValue == nullable.HasValue))
                      {
                        nullable = n.ProcesoId;
                        if (nullable.HasValue)
                          goto label_7;
                      }
                      return n.TipoEnvio == tracking.TipoEnvio || string.IsNullOrEmpty(n.TipoEnvio);
                    }
                  }
label_7:
                  return false;
                })).OrderByDescending<TraduccionEvento, string>((Func<TraduccionEvento, string>) (x => x.TipoEnvio)).OrderByDescending<TraduccionEvento, int?>((Func<TraduccionEvento, int?>) (x => x.ProcesoId)).OrderByDescending<TraduccionEvento, string>((Func<TraduccionEvento, string>) (x => x.Motivo)).ToList<TraduccionEvento>();
              }
              TrackingSync.Model.Elastic.Tracking tracking1 = Mapper.Map<TrackingSync.Model.Elastic.Tracking>((object) tracking);
              tracking1.id = (long) tracking.Id;
              bulkData.DocumentToIndex.Add(tracking1);
              string str2;
              SyncTask.Log.Info((Action<FormatMessageHandler>) (m => str2 = m("Tracking Id [{0}] added to bulk data as index.", new object[1]
              {
                (object) tracking.Id
              })));
            }
            else
            {
              TrackingSync.Model.Elastic.Tracking tracking2 = Mapper.Map<TrackingSync.Model.Elastic.Tracking>((object) tracking);
              tracking2.id = (long) int.Parse((string) entry);
              bulkData.DocumentToDelete.Add(tracking2);
              string str;
              SyncTask.Log.Info((Action<FormatMessageHandler>) (m => str = m("Tracking Id [{0}] added to bulk data as delete.", new object[1]
              {
                (object) int.Parse((string) entry)
              })));
            }
          }
        }
      }
      return bulkData;
    }

    private static string ObtenerTipoEnvioClasificado(TrackingSync.Model.Tracking tracking)
    {
      string valor = tracking.DatosAdicionales.Where<DatosAdicionales>((Func<DatosAdicionales, bool>) (d => d.Codigo.Equals("TipoDeServicio"))).FirstOrDefault<DatosAdicionales>()?.Valor;
      return valor == "LI Cambio" || valor == "LI Retiro" || valor == "RETIROS CON DOCUMENTACION" ? "Logistica Inversa" : (string) null;
    }

    private bool BulkData(BulkOperations bulkOperations)
    {
      bool flag;
      try
      {
        if (bulkOperations.DocumentToIndex.Count == 0)
        {
          SyncTask.Log.Warn((object) "No puedo enviar 0 documentos al Elastic. Reintento");
          return false;
        }
        ConnectionSettings connectionSettings = new ConnectionSettings(new Uri(ConfigurationManager.AppSettings["ElasticsearchUrl"]));
        connectionSettings.DefaultIndex(this.IndexName);
        string appSetting1 = ConfigurationManager.AppSettings["ElasticsearchUser"];
        string appSetting2 = ConfigurationManager.AppSettings["ElasticsearchPassword"];
        if (!string.IsNullOrEmpty(appSetting1) && !string.IsNullOrEmpty(appSetting2))
          connectionSettings.BasicAuthentication(appSetting1, appSetting2);
        BulkResponse response = new ElasticClient((IConnectionSettingsValues) connectionSettings).Bulk((Func<BulkDescriptor, IBulkRequest>) (b => (IBulkRequest) b.IndexMany<TrackingSync.Model.Elastic.Tracking>((IEnumerable<TrackingSync.Model.Elastic.Tracking>) bulkOperations.DocumentToIndex, (Func<BulkIndexDescriptor<TrackingSync.Model.Elastic.Tracking>, TrackingSync.Model.Elastic.Tracking, IBulkIndexOperation<TrackingSync.Model.Elastic.Tracking>>) ((d, s) => (IBulkIndexOperation<TrackingSync.Model.Elastic.Tracking>) d.Index((Nest.IndexName) this.IndexName).Id((Id) s.id))).DeleteMany<TrackingSync.Model.Elastic.Tracking>((IEnumerable<TrackingSync.Model.Elastic.Tracking>) bulkOperations.DocumentToDelete).Refresh(new Refresh?(Refresh.True))));
        if (response.Errors)
        {
          string str1;
          SyncTask.Log.Warn((Action<FormatMessageHandler>) (m => str1 = m("The last bulk was not success. Http Status Code {0}", new object[1]
          {
            (object) response.ServerError.Status
          })));
          string str2;
          SyncTask.Log.Warn((Action<FormatMessageHandler>) (m => str2 = m("The last bulk was not success. Server Error {0}", new object[1]
          {
            (object) response.ServerError
          })));
          string str3;
          SyncTask.Log.Warn((Action<FormatMessageHandler>) (m => str3 = m("The last bulk was not success. Original Exception {0}", new object[1]
          {
            (object) response.OriginalException?.Message
          })));
        }
        else
        {
          string str;
          SyncTask.Log.Info((Action<FormatMessageHandler>) (m => str = m("Bulk data was successfully delivered to ElasticSearch", Array.Empty<object>())));
        }
        flag = !response.Errors;
      }
      catch (Exception ex)
      {
        SyncTask.Log.Error((object) "Exception trying to bulk data to Elasticsearch.", ex);
        flag = false;
      }
      return flag;
    }

    private static string GetHumanReadableSize(long sum)
    {
      string humanReadableSize = string.Empty;
      Dictionary<double, string> dictionary = new Dictionary<double, string>();
      dictionary.Add(Math.Pow(1024.0, 3.0), "Gb");
      dictionary.Add(Math.Pow(1024.0, 2.0), "Mb");
      dictionary.Add(1024.0, "Kb");
      for (double key = Math.Pow(1024.0, 3.0); key >= 1024.0; key /= 1024.0)
      {
        if ((double) sum > key)
        {
          humanReadableSize = string.Format("{0:0.00} {1}", (object) ((double) sum / key), (object) dictionary[key]);
          break;
        }
      }
      if (sum < 1024L)
        humanReadableSize = "1kb";
      return humanReadableSize;
    }
  }
}
