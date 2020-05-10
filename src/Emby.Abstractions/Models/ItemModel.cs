using System.Collections.Generic;
using Newtonsoft.Json;

namespace Devpro.Emby.Abstractions.Models
{
    public enum MediaType
    {
        Video
    };

    public enum ItemType
    {
        Movie
    };

    public partial class ItemModel
    {
        public string Name { get; set; }

        public string ServerId { get; set; }

        public long Id { get; set; }

        public long RunTimeTicks { get; set; }

        public bool IsFolder { get; set; }

        [JsonProperty("Type")]
        public ItemType ItemType { get; set; }

        public UserDataModel UserData { get; set; }

        public ImageTagsModel ImageTags { get; set; }

        public List<string> BackdropImageTags { get; set; }

        public MediaType MediaType { get; set; }
    }
}
