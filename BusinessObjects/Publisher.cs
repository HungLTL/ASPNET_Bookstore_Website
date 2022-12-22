using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObjects
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
    }
}
