﻿// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles
namespace SharpCrokite.Core.StaticDataUpdater.Esi.EsiJsonModels
{
    public class EsiTypeJson
    {
        public int type_id { get; set; }
        public float capacity { get; set; }
        public string description { get; set; }
        public int group_id { get; set; }
        public int icon_id { get; set; }
        public int market_group_id { get; set; }
        public double mass { get; set; }
        public string name { get; set; }
        public decimal packaged_volume { get; set; }
        public int portion_size { get; set; }
        public bool published { get; set; }
        public decimal radius { get; set; }
        public decimal volume { get; set; }
    }
}
