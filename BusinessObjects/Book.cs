using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public int? Quantity { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual Publisher Publisher { get; set; }
        [JsonIgnore]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
