// Decompiled with JetBrains decompiler
// Type: TrackingSync.SpecialState.DiccionarioStrategy
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using System.Collections.Generic;

namespace TrackingSync.SpecialState
{
  public class DiccionarioStrategy
  {
    private static DiccionarioStrategy _instance;
    private readonly IDictionary<string, EstadoEspecial> _strategies;

    public static DiccionarioStrategy Instance => DiccionarioStrategy._instance ?? (DiccionarioStrategy._instance = new DiccionarioStrategy());

    private DiccionarioStrategy()
    {
      this._strategies = (IDictionary<string, EstadoEspecial>) new Dictionary<string, EstadoEspecial>();
      this._strategies.Add("EnvioEntregado", (EstadoEspecial) new EstadoEspecialEntregado());
      this._strategies.Add("EnvioNoEntregado", (EstadoEspecial) new EstadoEspecialNoEntregado());
      this._strategies.Add("RetiroRealizado", (EstadoEspecial) new EstadoEspecialRetiroExitoso());
      this._strategies.Add("RetiroFallido", (EstadoEspecial) new EstadoEspecialRetiroFallido());
    }

    public EstadoEspecial RetornarEstadoEspecialStrategy(string state)
    {
      EstadoEspecial estadoEspecial = (EstadoEspecial) null;
      if (state != null)
        this._strategies.TryGetValue(state, out estadoEspecial);
      return estadoEspecial;
    }
  }
}
