using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class Track
    {
        public Track()
        {
            InverseSourceTrack = new HashSet<Track>();
            TrackArtists = new HashSet<TrackArtists>();
            TrackTags = new HashSet<TrackTags>();
        }

        public Guid Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; }
        public int? Duration { get; set; }
        public Guid? SourceTrackId { get; set; }
        public Guid? AlbumId { get; set; }

        public Album Album { get; set; }
        public Track SourceTrack { get; set; }
        public ICollection<Track> InverseSourceTrack { get; set; }
        public ICollection<TrackArtists> TrackArtists { get; set; }
        public ICollection<TrackTags> TrackTags { get; set; }
    }
}
