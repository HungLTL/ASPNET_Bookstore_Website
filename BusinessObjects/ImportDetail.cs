using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class ImportDetail
    {
        public int ImportId { get; set; }
        public int BookId { get; set; }
        public int? Amount { get; set; }

        public virtual Book Book { get; set; }
        public virtual Import Import { get; set; }
    }
}
