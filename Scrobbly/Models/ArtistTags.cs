using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class ArtistTags
    {
        public Guid ArtistId { get; set; }
        public Guid TagId { get; set; }

        public Artist Artist { get; set; }
        public Tag Tag { get; set; }
    }
}
