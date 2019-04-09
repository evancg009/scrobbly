using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class TrackTags
    {
        public Guid TrackId { get; set; }
        public Guid TagId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Track Track { get; set; }
    }
}
