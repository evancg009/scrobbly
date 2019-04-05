using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class TrackTags
    {
        public Guid TrackId { get; set; }
        public Guid TagId { get; set; }

        public Tag Tag { get; set; }
        public Track Track { get; set; }
    }
}
