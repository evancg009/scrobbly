using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class Play
    {
        public Guid Id { get; set; }
        public string AlbumName { get; set; }
        public string[] ArtistNames { get; set; }
        public bool Dirty { get; set; }
        public DateTime ListenTime { get; set; }
        public short? Popularity { get; set; }
        public Guid? TrackId { get; set; }
        public string TrackName { get; set; }
        public string SourceOf { get; set; }
        public string TrackSpotifyId { get; set; }
        public string[] ArtistSpotifyIds { get; set; }
        public string AlbumSpotifyId { get; set; }
        public int? TrackDuration { get; set; }
        public string AlbumImage { get; set; }

        public virtual Track Track { get; set; }
    }
}
