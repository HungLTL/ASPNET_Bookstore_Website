using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public decimal? Rating { get; set; }
        public string Comment { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
