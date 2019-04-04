﻿using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class Track
    {
        public Track()
        {
            TrackAlbums = new HashSet<TrackAlbums>();
            TrackArtists = new HashSet<TrackArtists>();
        }

        public Guid Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; }
        public string[] AltNames { get; set; }
        public int? Duration { get; set; }

        public ICollection<TrackAlbums> TrackAlbums { get; set; }
        public ICollection<TrackArtists> TrackArtists { get; set; }
    }
}
