﻿using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class WorldCity
    {
        public WorldCity()
        {
            ArtistCurrentWorldCity = new HashSet<Artist>();
            ArtistHomeWorldCity = new HashSet<Artist>();
            InverseClosestMajorCity = new HashSet<WorldCity>();
        }

        public int WorldCityId { get; set; }
        public string CityName { get; set; }
        public int? ClosestMajorCityId { get; set; }
        public int WorldRegionId { get; set; }
        public bool MajorCity { get; set; }

        public virtual WorldCity ClosestMajorCity { get; set; }
        public virtual WorldRegion WorldRegion { get; set; }
        public virtual ICollection<Artist> ArtistCurrentWorldCity { get; set; }
        public virtual ICollection<Artist> ArtistHomeWorldCity { get; set; }
        public virtual ICollection<WorldCity> InverseClosestMajorCity { get; set; }
    }
}
