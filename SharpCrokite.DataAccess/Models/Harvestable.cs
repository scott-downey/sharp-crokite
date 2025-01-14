﻿using System.Collections.Generic;
using System.Diagnostics;

namespace SharpCrokite.DataAccess.Models
{
    [DebuggerDisplay("{Type} - {Name}")]
    public class Harvestable
    {
        public int HarvestableId { get; init; }
        public string Type { get; set; }
        public byte[] Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Volume { get; set; }
        public List<MaterialContent> MaterialContents { get; set; } = new();
        public List<Price> Prices { get; set; } = new();
        public int? IsCompressedVariantOfTypeId { get; set; }
        public int? CompressedVariantTypeId { get; set; }
    }
}
