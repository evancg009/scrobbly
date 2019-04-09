using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class AlbumArtists
    {
        public Guid AlbumId { get; set; }
        public Guid ArtistId { get; set; }

        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
