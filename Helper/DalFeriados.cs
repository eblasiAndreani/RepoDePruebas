// Decompiled with JetBrains decompiler
// Type: TrackingSync.Helper.DalFeriados
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TrackingSync.Helper
{
  public class DalFeriados
  {
    private static string _ConnectionString = (string) null;

    static DalFeriados() => DalFeriados._ConnectionString = ConfigurationManager.AppSettings["FeriadosConnectionString"];

    public static List<DateTime> ObtenerFeriados()
    {
      List<DateTime> dateTimeList = new List<DateTime>();
      DataSet dataSet = new DataSet();
      string cmdText = "select fecha from dgov.fact_feriado";
      using (SqlConnection connection = new SqlConnection(DalFeriados._ConnectionString))
      {
        using (SqlCommand selectCommand = new SqlCommand(cmdText, connection))
        {
          using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
            sqlDataAdapter.Fill(dataSet);
        }
      }
      foreach (DataRow row in (InternalDataCollectionBase) dataSet.Tables[0].Rows)
        dateTimeList.Add(Convert.ToDateTime(row.ItemArray[0]));
      return dateTimeList;
    }
  }
}
