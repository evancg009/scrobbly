using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class Track
    {
        public Track()
        {
            InverseSourceTrack = new HashSet<Track>();
            Play = new HashSet<Play>();
            TrackArtists = new HashSet<TrackArtists>();
            TrackTags = new HashSet<TrackTags>();
        }

        public Guid Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; }
        public int? Duration { get; set; }
        public Guid? SourceTrackId { get; set; }
        public Guid? AlbumId { get; set; }

        public virtual Album Album { get; set; }
        public virtual Track SourceTrack { get; set; }
        public virtual ICollection<Track> InverseSourceTrack { get; set; }
        public virtual ICollection<Play> Play { get; set; }
        public virtual ICollection<TrackArtists> TrackArtists { get; set; }
        public virtual ICollection<TrackTags> TrackTags { get; set; }
    }
}
