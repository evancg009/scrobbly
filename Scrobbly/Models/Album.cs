using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string Image { get; set; }

        [Display(Name = "Artist(s)")]
        public virtual ICollection<AlbumArtists> AlbumArtists { get; set; }
        public virtual ICollection<AlbumTags> AlbumTags { get; set; }
        public virtual ICollection<Track> Track { get; set; }
    }
}
