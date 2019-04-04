using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class TrackArtists
    {
        public Guid TrackId { get; set; }
        public Guid ArtistId { get; set; }

        public Artist Artist { get; set; }
        public Track Track { get; set; }
    }
}
