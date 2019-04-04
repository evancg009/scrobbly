using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class Artist
    {
        public Artist()
        {
            AlbumArtists = new HashSet<AlbumArtists>();
            TrackArtists = new HashSet<TrackArtists>();
        }

        public Guid Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; }
        public string[] AltNames { get; set; }

        public ICollection<AlbumArtists> AlbumArtists { get; set; }
        public ICollection<TrackArtists> TrackArtists { get; set; }
    }
}
