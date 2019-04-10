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
        [Display(Name = "Album Cover")]
        public string Image { get; set; }

        [Display(Name = "Artists")]
        public virtual ICollection<AlbumArtists> AlbumArtists { get; set; }
        [Display(Name = "Tags")]
        public virtual ICollection<AlbumTags> AlbumTags { get; set; }
        [Display(Name = "Tracks")]
        public virtual ICollection<Track> Track { get; set; }
    }
}
