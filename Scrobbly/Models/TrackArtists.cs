using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class TrackArtists
    {
        public Guid TrackId { get; set; }
        public Guid ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Track Track { get; set; }
    }
}
