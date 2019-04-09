using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class Tag
    {
        public Tag()
        {
            AlbumTags = new HashSet<AlbumTags>();
            ArtistTags = new HashSet<ArtistTags>();
            TrackTags = new HashSet<TrackTags>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AlbumTags> AlbumTags { get; set; }
        public virtual ICollection<ArtistTags> ArtistTags { get; set; }
        public virtual ICollection<TrackTags> TrackTags { get; set; }
    }
}
