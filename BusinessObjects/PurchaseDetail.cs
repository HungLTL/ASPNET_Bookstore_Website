using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObjects
{
    public partial class PurchaseDetail
    {
        public int PurchaseId { get; set; }
        public int BookId { get; set; }
        public int? Amount { get; set; }

        [JsonIgnore]
        public virtual Book Book { get; set; }
        [JsonIgnore]
        public virtual Purchase Purchase { get; set; }
    }
}
