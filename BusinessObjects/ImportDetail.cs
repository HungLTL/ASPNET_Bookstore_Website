using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObjects
{
    public partial class ImportDetail
    {
        public int ImportId { get; set; }
        public int BookId { get; set; }
        public int? Amount { get; set; }
        public int Id { get; set; }

        [JsonIgnore]
        public virtual Book Book { get; set; }
        [JsonIgnore]
        public virtual Import Import { get; set; }
    }
}
