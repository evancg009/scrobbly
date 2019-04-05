using System;
using System.Collections.Generic;

namespace Scrobbly.Models
{
    public partial class AlbumTags
    {
        public Guid AlbumId { get; set; }
        public Guid TagId { get; set; }

        public Album Album { get; set; }
        public Tag Tag { get; set; }
    }
}
