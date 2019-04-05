using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class Album
    {
        public Album()
        {
            AlbumArtists = new HashSet<AlbumArtists>();
            AlbumTags = new HashSet<AlbumTags>();
            Track = new HashSet<Track>();
        }

        public Guid Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; }

        public ICollection<AlbumArtists> AlbumArtists { get; set; }
        public ICollection<AlbumTags> AlbumTags { get; set; }
        public ICollection<Track> Track { get; set; }
    }
}
