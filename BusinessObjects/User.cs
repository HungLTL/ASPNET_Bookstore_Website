﻿using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class User
    {
        public User()
        {
            Imports = new HashSet<Import>();
            Purchases = new HashSet<Purchase>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public DateOnly? Dob { get; set; }
        public string Address { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Import> Imports { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
