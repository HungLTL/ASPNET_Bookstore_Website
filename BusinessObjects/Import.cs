using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObjects
{
    public partial class Import
    {
        public Import()
        {
            ImportDetails = new HashSet<ImportDetail>();
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateOnly? Date { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }
    }
}
