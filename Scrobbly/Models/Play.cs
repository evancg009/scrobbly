using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class Play
    {
        public Guid Id { get; set; }
        public Guid? AlbumId { get; set; }
        public string AlbumName { get; set; }
        public Guid[] ArtistIds { get; set; }
        public string[] ArtistNames { get; set; }
        public bool Dirty { get; set; }
        public DateTime ListenTime { get; set; }
        public short? Popularity { get; set; }
        public Guid TrackId { get; set; }
        public string TrackName { get; set; }
        public string SourceOf { get; set; }
    }
}
