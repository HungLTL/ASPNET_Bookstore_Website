using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObjects
{
    public partial class Author
    {
        public Author()
        {
            Bookauthors = new HashSet<Bookauthor>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Bookauthor> Bookauthors { get; set; }
    }
}
