using System.Collections.Generic;

namespace Devpro.Emby.Abstractions.Models
{
    public partial class ResultModel<T>
    {
        public List<T> Items { get; set; }

        public long TotalRecordCount { get; set; }
    }
}
