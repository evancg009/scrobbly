using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class TrackAlbums
    {
        public Guid TrackId { get; set; }
        public Guid AlbumId { get; set; }

        public virtual Album Album { get; set; }
        public virtual Track Track { get; set; }
    }
}
