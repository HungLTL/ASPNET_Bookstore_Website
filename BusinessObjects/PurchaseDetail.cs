using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class PurchaseDetail
    {
        public int PurchaseId { get; set; }
        public int BookId { get; set; }
        public int? Amount { get; set; }

        public virtual Book Book { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}
