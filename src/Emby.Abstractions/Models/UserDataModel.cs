using System;

namespace Devpro.Emby.Abstractions.Models
{
    public class UserDataModel
    {
        public long PlaybackPositionTicks { get; set; }

        public long PlayCount { get; set; }

        public bool IsFavorite { get; set; }

        public bool Played { get; set; }

        public DateTime? LastPlayedDate { get; set; }
    }
}
