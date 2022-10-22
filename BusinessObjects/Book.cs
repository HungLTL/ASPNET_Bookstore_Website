using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Book
    {
        public Book()
        {
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public int? PublishedYear { get; set; }
        public decimal? UnitPrice { get; set; }
        public byte[] Image { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
