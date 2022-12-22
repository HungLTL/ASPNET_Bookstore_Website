using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObjects
{
    public partial class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public decimal? Rating { get; set; }
        public string Comment { get; set; }

        [JsonIgnore]
        public virtual Book Book { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
