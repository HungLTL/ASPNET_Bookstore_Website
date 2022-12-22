using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObjects
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Category1 { get; set; }

        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
    }
}
