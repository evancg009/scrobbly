using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class Album
    {
        public Album()
        {
            AlbumArtists = new HashSet<AlbumArtists>();
            TrackAlbums = new HashSet<TrackAlbums>();
        }

        public Guid Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; }
        public string[] AltNames { get; set; }

        public ICollection<AlbumArtists> AlbumArtists { get; set; }
        public ICollection<TrackAlbums> TrackAlbums { get; set; }
    }
}
