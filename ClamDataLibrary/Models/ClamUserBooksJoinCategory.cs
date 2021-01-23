using System;
using System.Collections.Generic;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamUserBooksJoinCategory
    {
        public Guid BookId { get; set; }
        public ClamUserBooks ClamUserBooks { get; set; }

        public Guid CategoryId { get; set; }
        public ClamUserBooksCategory ClamUserBooksCategory { get; set; }
    }
}
