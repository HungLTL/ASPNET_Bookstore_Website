using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Bookauthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
