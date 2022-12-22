using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObjects
{
    public partial class Bookauthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        [JsonIgnore]
        public virtual Author Author { get; set; }
        [JsonIgnore]
        public virtual Book Book { get; set; }
    }
}
