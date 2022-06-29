// Decompiled with JetBrains decompiler
// Type: TrackingSync.Helper.RedisItems
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using StackExchange.Redis;
using System.Collections.Generic;

namespace TrackingSync.Helper
{
  public class RedisItems
  {
    private static RedisItems _instance;
    public RedisValue[] QueueEntries;
    public string QueueName = "ElasticSync";

    public static RedisItems Instance => RedisItems._instance ?? (RedisItems._instance = new RedisItems());

    public void InstanciarValoresDeRedis(RedisValue[] redisValues) => this.QueueEntries = redisValues;

    public string ObtenerListaDeValoreRedis() => string.Join<RedisValue>(";", (IEnumerable<RedisValue>) this.QueueEntries);
  }
}
