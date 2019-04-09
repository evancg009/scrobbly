using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class ArtistTags
    {
        public Guid ArtistId { get; set; }
        public Guid TagId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
