using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObjects
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Role1 { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
