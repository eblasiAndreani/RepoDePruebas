// Decompiled with JetBrains decompiler
// Type: TrackingSync.Helper.Cache
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using System;
using System.Collections.Generic;

namespace TrackingSync.Helper
{
  public class Cache
  {
    private static Cache _instance;
    protected Dictionary<string, object> _dic;
    protected DateTime _tiempoUltimoRefresco;

    public static Cache Instance => Cache._instance ?? (Cache._instance = new Cache());

    public Cache()
    {
      this._dic = new Dictionary<string, object>();
      this._tiempoUltimoRefresco = DateTime.Now;
    }

    public static void Reciclar() => Cache._instance = new Cache();

    public IList<T> Resolver<T>(string key)
    {
      if (key == null)
        return (IList<T>) null;
      lock (this._dic)
      {
        object obj;
        if (this._dic.TryGetValue(key, out obj))
          return (IList<T>) obj;
        List<T> objList = new List<T>();
        this._dic.Add(key, (object) objList);
        return (IList<T>) objList;
      }
    }

    public void Insertar<T>(string key, T value)
    {
      lock (this._dic)
      {
        if (this._dic.ContainsKey(key))
          return;
        this._dic.Add(key, (object) value);
      }
    }

    public bool IsEmpty => this._dic.Count == 0;

    public bool CalcularSiDebeRefrescar() => (DateTime.Now - this._tiempoUltimoRefresco).TotalMinutes > 60.0;
  }
}
