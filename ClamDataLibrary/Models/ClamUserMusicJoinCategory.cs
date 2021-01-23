using System;
using System.Collections.Generic;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamUserMusicJoinCategory
    {
        public Guid SongId { get; set; }
        public ClamUserMusic ClamUserMusic { get; set; }

        public Guid CategoryId { get; set; }
        public ClamUserMusicCategory ClamUserMusicCategory { get; set; }
    }
}
