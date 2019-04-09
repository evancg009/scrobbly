using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class Artist
    {
        public Artist()
        {
            AlbumArtists = new HashSet<AlbumArtists>();
            ArtistTags = new HashSet<ArtistTags>();
            TrackArtists = new HashSet<TrackArtists>();
        }

        public Guid Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AlbumArtists> AlbumArtists { get; set; }
        public virtual ICollection<ArtistTags> ArtistTags { get; set; }
        public virtual ICollection<TrackArtists> TrackArtists { get; set; }
    }
}
