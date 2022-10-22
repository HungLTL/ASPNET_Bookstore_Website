using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Purchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateOnly? Date { get; set; }
        public decimal? Discount { get; set; }

        public virtual User User { get; set; }
    }
}
