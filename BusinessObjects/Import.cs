using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Import
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateOnly? Date { get; set; }

        public virtual User User { get; set; }
    }
}
