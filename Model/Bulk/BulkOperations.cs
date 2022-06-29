// Decompiled with JetBrains decompiler
// Type: TrackingSync.Model.Bulk.BulkOperations
// Assembly: TrackingSync, Version=2.7.15.0, Culture=neutral, PublicKeyToken=null
// MVID: E07B935D-5789-45B5-89D4-6E2ECB11FF08
// Assembly location: C:\Users\cesar\OneDrive\Escritorio\TRABAJO\tracking\TrackingSync\TrackingSync.exe

using System.Collections.Generic;

namespace TrackingSync.Model.Bulk
{
  public class BulkOperations
  {
    public BulkOperations()
    {
      this.DocumentToIndex = (IList<TrackingSync.Model.Elastic.Tracking>) new List<TrackingSync.Model.Elastic.Tracking>();
      this.DocumentToDelete = (IList<TrackingSync.Model.Elastic.Tracking>) new List<TrackingSync.Model.Elastic.Tracking>();
    }

    public IList<TrackingSync.Model.Elastic.Tracking> DocumentToIndex { get; set; }

    public IList<TrackingSync.Model.Elastic.Tracking> DocumentToDelete { get; set; }
  }
}
