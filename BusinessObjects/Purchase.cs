using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObjects
{
    public partial class Purchase
    {
        public Purchase()
        {
            PurchaseDetails = new HashSet<PurchaseDetail>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateOnly? Date { get; set; }
        public decimal? Discount { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
